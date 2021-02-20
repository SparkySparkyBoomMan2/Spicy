using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Main : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem BulletExplode;
    public float BulletSpeed;
    void Start()
    {
        //Makes the bullet have a starting velocity
        //might change depending on instantiated rotation of bullet
        rb.velocity = new Vector3(transform.right.y, transform.right.x * -1, transform.right.z) * BulletSpeed;
    }
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bullet is impacting --[" + other.gameObject.tag + "]");

        BulletImpact();
    }

    //Instantiates a new "impact" particle effect for the bullet
    // * destroys the bullet, but not particle system
    // * particle system is destroyed in a seperate script
    void BulletImpact()
    {
        Instantiate(BulletExplode, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }
}
