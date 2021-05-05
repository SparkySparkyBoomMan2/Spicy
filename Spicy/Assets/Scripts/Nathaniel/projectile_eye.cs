using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_eye : death_tomato
{
    GameObject target;
    public float speedProjectile;
    Rigidbody2D rigidProjectile;
    Transform projPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        rigidProjectile = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Gun");
        if (target != null) {
            Vector2 moveTowardsPosition = (target.transform.position - transform.position) * speedProjectile;
            rigidProjectile.velocity = new Vector2(moveTowardsPosition.x, moveTowardsPosition.y);
            Destroy(this.gameObject, 2);
        }
    }


    //damages player if hits
    //inherites damage player from death_tomato
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("In first Collisiont");
        if(other.gameObject.tag == "Gun")
        {
            Debug.Log("Hit player with bullet");
            DamagePlayer(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
