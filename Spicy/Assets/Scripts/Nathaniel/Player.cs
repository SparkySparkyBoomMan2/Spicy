using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck = null; //gameObject is made for the ground detection
    [SerializeField] private LayerMask playerMask; //uses the layer we create for player
    bool jumpPressed;
    float xInput;
    Rigidbody rigidbodyComponent;
    int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //initializes jumpPressed as true
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpPressed = true;
        }

        //gets xInput for horizontal movement
        xInput = Input.GetAxis("Horizontal");
    }

    //fixed update for physics
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(xInput * speed, rigidbodyComponent.velocity.y, 0); //horizontal movement physics

        if (Physics.OverlapSphere(groundCheck.position, 0.1f, playerMask).Length == 0) //add detections to prevent double jump
        {
            return;
        }

        if (jumpPressed) //activates the jump and resets jump key back to false
        {
            Debug.Log("Jump Key Pressed"); //debugs for when key pressed
            rigidbodyComponent.AddForce(Vector2.up * 6, ForceMode.VelocityChange);
            jumpPressed = false;
        }
    }
}
