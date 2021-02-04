using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem BulletExplode;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(transform.right.y, transform.right.x * -1, transform.right.z) * 10f;
        //rb.velocity = new Vector3( transform.right.x, transform.right.y, transform.right.z) * 10f;
    }

    // Update is called once per frame
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
        //rb.velocity = new Vector2(rb.velocity.x, -2);
        Instantiate(BulletExplode, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
        //Destroy(BulletExplode);
        Debug.Log("META");
    }
}
