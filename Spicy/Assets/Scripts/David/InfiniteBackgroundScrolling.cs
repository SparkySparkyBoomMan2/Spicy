using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgroundScrolling : MonoBehaviour
{
    private float xLength, xStartPosition;
    //private float yLength, yStartPosition;
    public float speed;
    public int offset;

    void Start()
    {
        xStartPosition = transform.position.x;
        xLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(xStartPosition + Time.time * speed, transform.position.y);

        transform.position = new Vector2(Mathf.Repeat(Time.time * speed, xLength) + offset * xLength, transform.position.y);

        //if (transform.position.x > xStartPosition + xLength)
        //{
        //    Vector2 offset = new Vector2(xLength * 3f, 0);
       //     transform.position = (Vector2)transform.position - offset;
        //}     
    }
}
