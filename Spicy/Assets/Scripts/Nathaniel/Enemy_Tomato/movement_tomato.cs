using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class movement_tomato : MonoBehaviour
{
    System.Random GetRandom;
    
    private float walk_speed = 1.0f;
    bool moveRight = true;
    public Transform wallDetect;

    // Update is called once per frame
    void Update()
    {
        runMovement();
        Debug.Log("Rand" + GetRandom);
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
}
