using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Main : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem BulletExplode;
    void Start()
    {
        //Makes the bullet have a starting velocity
        //might change depending on instantiated rotation of bullet
        rb.velocity = new Vector3(transform.right.y, transform.right.x * -1, transform.right.z) * 10f;
    }
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);

        //if (other.gameObject.name == "TilemapPlatforms")
        if (other.gameObject.name != "Player")
        {
            BulletImpact();
        }
    }

    void BulletImpact()
    {
        Instantiate(BulletExplode, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }
}
