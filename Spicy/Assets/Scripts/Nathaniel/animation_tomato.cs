using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_tomato : MonoBehaviour
{
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
        runAnimations();
    }
    void runAnimations()
    {
        currentPosition = rigidbody2d.position; //gets position for animations
        //setting up animator
        animator.SetFloat("Horizontal", currentPosition.x);
        animator.SetFloat("Horizontal", currentPosition.y);
        animator.SetFloat("Speed", currentPosition.sqrMagnitude);
    }
}
