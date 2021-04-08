using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class movement_tomato : MonoBehaviour
{

    public float walk_speed = 1.0f;
    bool moveRight = true;
    System.Random random = new System.Random();
    int randVal;
    public Transform wallDetectRight;
    public Transform wallDetectLeft;
    public Transform groundDetect1;
    public Transform groundDetect2;

    private void Start()
    {
        randVal = random.Next(2);
        Debug.Log("RandVal " + randVal);
    }
    // Update is called once per frame
    void Update()
    {

        runMovement();

    }


    public int runMovement()
    {
        int dirFlag = 2;
        RaycastHit2D wallInfoRight = Physics2D.Raycast(wallDetectRight.position, Vector2.right, .01f);
        //RaycastHit2D wallInfoLeft = Physics2D.Raycast(wallDetectLeft.position, Vector2.left, .01f);
        RaycastHit2D groundInfo1 = Physics2D.Raycast(groundDetect1.position, Vector2.down, .01f);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDetect2.position, Vector2.down, .01f);

        Debug.DrawLine(transform.position, wallDetectRight.position, Color.green);
        //Debug.DrawLine(transform.position, wallDetectLeft.position, Color.blue);
        Debug.DrawLine(transform.position, groundDetect1.position, Color.blue);
        Debug.DrawLine(transform.position, groundDetect2.position, Color.red);

        if (groundInfo1.collider == true || groundInfo2.collider == true) //trying to set only linear movement if on ground
        {
            //Debug.Log("Tomato On Ground");
            if(randVal == 1)
            {
                transform.Translate(Vector2.right * walk_speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
                moveRight = false;
                randVal = 0;
            }
            else
            {
                transform.Translate(Vector2.right * walk_speed * Time.deltaTime);
            }
        }
        else
        {
            //Debug.Log("Tomato Off Ground");
            transform.Translate(Vector2.down * walk_speed * Time.deltaTime);
        }

        if (wallInfoRight.collider == true) //detects wall collission
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector2(0, 180);
                moveRight = false;
                dirFlag = 1;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveRight = true;
                dirFlag = 0;
            }
        }

        return dirFlag;
    }
}
