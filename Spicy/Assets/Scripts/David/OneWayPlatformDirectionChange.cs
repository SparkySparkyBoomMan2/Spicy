using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class effect does not take into account multiplayer settings.
// Unsure how this behavior works if multiple players pressing UP, DOWN or JUMP at the same time
public class OneWayPlatformDirectionChange : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime = 0.5f;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // May want to change this to work with just axis input instead of specific keys
    // Especially important in the case of using a controller or touch over keyboard
    void Update()
    {
        // If UP or DOWN are released, the wait time to flip the one-way platform direction resets
        if (Input.GetButtonUp("Vertical"))
        {
            waitTime = 0.5f;
        }

        // This currently allows for both UP and DOWN to affect hold time for platform direction change
        // Pressing|Holding|Releasing DOWN count down a timer to switch the one-way platform direction
        if (Input.GetButton("Vertical"))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        // If JUMP is pressed, the one-way platform direction resets to the default direction
        if (Input.GetButtonDown("Jump"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
