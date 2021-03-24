using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class movement_tomato : MonoBehaviour
{

    private float walk_speed = 1.0f;
    bool moveRight = true;
    public Transform wallDetect;
    public Transform groundDetect1;
    public Transform groundDetect2;


    // Update is called once per frame
    void Update()
    {
        runMovement();
    }


    public int runMovement()
    {
        int dirFlag = 2;
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetect.position, Vector2.right, .01f);
        RaycastHit2D groundInfo1 = Physics2D.Raycast(groundDetect1.position, Vector2.down, .01f);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDetect2.position, Vector2.down, .01f);

        Debug.DrawLine(transform.position, wallDetect.position, Color.green);
        Debug.DrawLine(transform.position, groundDetect1.position, Color.blue);
        Debug.DrawLine(transform.position, groundDetect2.position, Color.blue);

        if (groundInfo1.collider == true || groundInfo2.collider == true) //trying to set only linear movement if on ground
        {
            //Debug.Log("Tomato On Ground");
            transform.Translate(Vector2.right * walk_speed * Time.deltaTime);
        }
        else
        {
            //Debug.Log("Tomato Off Ground");
            transform.Translate(Vector2.down * walk_speed * Time.deltaTime);
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
}
