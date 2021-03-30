using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgroundScrolling : MonoBehaviour
{
    private float xLength, xStartPosition;
    private float yLength, yStartPosition;
    public float speed;

    void Start()
    {
        xStartPosition = transform.position.x;
        xLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(Mathf.Repeat(Time.deltaTime, speed), transform.position.y);



        
    }
}
