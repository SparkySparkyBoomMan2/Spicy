using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jumpPressed;

    float xInput;
    public float speed = 4;
    public float jumpForce = 9;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //initializes jumpPressed as true
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2D.velocity.y) < 0.001f)
        {
            jumpPressed = true;
        }

        //gets xInput for horizontal movement
        xInput = Input.GetAxis("Horizontal"); //gets horizontal input
    }

    //fixed update for physics
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(xInput * speed, rigidbody2D.velocity.y); //horizontal movement physics

        if (jumpPressed) //activates the jump and resets jump key back to false
        {
            Debug.Log("Jump Key Pressed"); //debugs for when key pressed
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // jump physics
            jumpPressed = false;
        }
    }

}
