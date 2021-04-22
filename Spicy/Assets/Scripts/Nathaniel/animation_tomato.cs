using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_tomato : MonoBehaviour
{
    //calling in the animator
    //creating a vector variable for the rigidbody

    public Animator animator;
    Vector2 currentPosition;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAnimations();
    }

    //Tells animator the direction in which the tomato is travelling
    //Grabbing the position from the rigidbody of the tomato

    void RunAnimations()
    {
        currentPosition = rigidbody2d.position;
        animator.SetFloat("Horizontal", currentPosition.x);
        animator.SetFloat("Horizontal", currentPosition.y);
        animator.SetFloat("Speed", currentPosition.sqrMagnitude);
    }
}
