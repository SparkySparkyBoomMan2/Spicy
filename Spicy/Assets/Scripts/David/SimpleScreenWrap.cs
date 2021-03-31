using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScreenWrap : MonoBehaviour
{
    [SerializeField]
    private float horizontalOffset, verticalOffset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector2(collision.transform.position.x + horizontalOffset, collision.transform.position.y + verticalOffset);
    }
}
