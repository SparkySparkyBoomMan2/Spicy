using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato_Enemy : MonoBehaviour
{
    public Transform Tomato;
    float walk_speed = 2f;
    float step;
    float dir = 0f;
    Vector2 direction;
    bool isGrounded;
    bool isWalled;

    //Animations
    public GameObject walk;
    public GameObject explode;
    public GameObject idle;


    Rigidbody2D rigidbody2d;

    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        idle.SetActive(true);
        rigidbody2d = GetComponent<Rigidbody2D>();
        step = walk_speed * Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rigidbody2d.velocity.y) < 0.001f)
        {
            isGrounded = true;
        }

        if (Mathf.Abs(rigidbody2d.velocity.x) > 0.001f)
        {
            isWalled = true;
        }
    }

    private void FixedUpdate()
    {
        
        if (isGrounded)
        {
            idle.SetActive(false);
            walk.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Tomato.position.x + dir, Tomato.position.y), step);
            isGrounded = false;
        }
        if (!isGrounded)
        {
            walk.SetActive(false);
            idle.SetActive(true);
        }

        change_direction();
        
    }

    void change_direction()
    {
       if (isWalled)
        {
            dir = 2f;
            isWalled = false;
        }
        else if(!isWalled)
        {
            dir = 2f;
        }
    }
}
