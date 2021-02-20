using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Move : MonoBehaviour
{
    public Rigidbody2D ghost;
    private float speed = 1f;
    private float speedY = 1f;
    private float oscillator = 0f;
    private float increment = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize ghost enemy attributes
        ghost = GetComponent<Rigidbody2D>();
        //Set Speed
        ghost.velocity = new Vector2(speed, speedY * oscillator);
        //Animator stuffs?

        //Set up player detection?
    }

    // Update is called once per frame
    void Update()
    {
        //Check surroundings
    }

    void FixedUpdate()
    {
        //Update velocity direction
        ghost.velocity = new Vector2(speed, speedY * oscillator);
        if (increment > 2 * Mathf.PI)
        {
            increment = 0f;
        }
        else
        {
            increment += 0.05f;
        }
        oscillator = Mathf.Sin(increment);
    }

    void OnCollisionEnter2D()
    {
        speed = -1 * speed;
    }
}
