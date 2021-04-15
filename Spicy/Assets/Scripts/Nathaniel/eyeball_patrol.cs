using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeball_patrol : MonoBehaviour
{
    public float flySpeed = 1f;

    [HideInInspector]
    public bool isPatrol;
    private bool isFlip;

    public Rigidbody2D rg2d;
    public Transform isWallCheck;
    public LayerMask wallLayer;
    public Collider2D bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        isPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
        if (isPatrol)
        {
            isFlip = Physics2D.OverlapCircle(isWallCheck.position, 0.1f, wallLayer);
        }
    }
    void Patrol()
    {
        if (isFlip || bodyCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
        }
        rg2d.velocity = new Vector2(flySpeed * Time.fixedDeltaTime, rg2d.velocity.y);
    }

    void Flip()
    {
        isPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        flySpeed *= -1;
        isPatrol = true;
    }
}
