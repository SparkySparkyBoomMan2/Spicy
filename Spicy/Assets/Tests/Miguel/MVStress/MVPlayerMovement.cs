using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// This stress tests the dash speed of the player by testing when or if they go out of bounds
namespace Tests
{
    public class MVPlayerMovement
    {
        // 	Identifies methods to be called once prior to any child tests.
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("MVTestMovementScene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DashOutOfBounds()
        {
            float dashSpeed = 1f;
            int i = 0;
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameObject player = GameObject.Find("Player");
            while (i< 1000)
            {
                player.GetComponent<Movement>().dashSpeed = dashSpeed;
                player.GetComponent<Movement>().Dash(0, -1);  // Dash Down
                yield return 60;
                Assert.IsTrue(player.transform.position.y > -6);
                dashSpeed = 2 * dashSpeed;
                Debug.Log("Dash Speed: " + dashSpeed);
                Debug.Log("Loop Count: " + i);
                i++;
            }
        }
    }
}
