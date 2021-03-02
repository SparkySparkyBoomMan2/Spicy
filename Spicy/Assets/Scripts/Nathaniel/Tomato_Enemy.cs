using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato_Enemy : MonoBehaviour
{
    public Transform Tomato;
    private float walk_speed = 10;
    
    bool moveRight = true;
    public Transform wallDetect;

    Vector2 currPosition;
    Rigidbody2D rigidbody2d;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        runAnimations();
        runMovement();
    }

    void runAnimations()
    {
        currPosition = rigidbody2d.position; //gets position for animations
        //setting up animator
        animator.SetFloat("Horizontal", currPosition.x);
        animator.SetFloat("Horizontal", currPosition.y);
        animator.SetFloat("Speed", currPosition.sqrMagnitude);
    }
    public int runMovement()
    {
        int dirFlag = 2;
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetect.position, Vector2.right, .01f);
        RaycastHit2D groundInfo = Physics2D.Raycast(wallDetect.position, Vector2.down, .01f);

        if (groundInfo.collider == false) //trying to set only linear movement if on ground
        {
            transform.Translate(Vector2.right * walk_speed * Time.deltaTime);
        }

        if (wallInfo.collider == true) //detects wall collission
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveRight = false;
                dirFlag = 1;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
                dirFlag = 0;
            }
        }
        return dirFlag;
    }
    public void Die() //kills tomato enemy
    {
        animator.SetBool("isDead", false); //turns on explode animation
        Destroy(gameObject, 1.04f); 
    }

    public void setSpeed(float spd)
    {
        this.walk_speed = spd;
    }
    public Vector2 getPosition()
    {
        return this.currPosition;
    }
}
