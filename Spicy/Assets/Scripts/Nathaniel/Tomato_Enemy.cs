using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato_Enemy : MonoBehaviour
{
    public Transform Tomato;
    public float walk_speed;

    bool moveRight = true;
    public Transform wallDetect;

    Vector2 currPosition;
    Rigidbody2D rigidbody2d;

    public Animator animator;
    public GameObject deathEffect;
    public new Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currPosition = rigidbody2d.position; //gets position for animations
        //setting up animator
        animator.SetFloat("Horizontal", currPosition.x);
        animator.SetFloat("Horizontal", currPosition.y);
        animator.SetFloat("Speed", currPosition.sqrMagnitude);

       // transform.Translate(Vector2.right * walk_speed * Time.deltaTime);

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetect.position, Vector2.right, .01f);
        RaycastHit2D groundInfo = Physics2D.Raycast(wallDetect.position, Vector2.down, .01f);

        if (groundInfo.collider == false) //trying to set only linear movement if on ground
        {
            transform.Translate(Vector2.right * walk_speed * Time.deltaTime);
        }

        if (wallInfo.collider == true) //detects wall collission
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        
    }
}
