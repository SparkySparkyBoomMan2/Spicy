using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_default : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem BulletExplode;
    public float BulletSpeed;
    public int Damage = 50;
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
        //Debug.Log("Bullet is impacting --[" + other.gameObject.tag + "]");

       
        if (other.gameObject.tag == "Enemy")
        {
            BulletImpact();
            DamageEnemy(other);
        }
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

    //If the object collided with is an enemy, damage that enemy
    // * for now, only designed to work with tomato enemy
    // * takes off 'damage' amount of health
    //   - defined in public global variable
    //   - TakeDamage() function expected to be defined in Tomato_Enemy script!
    void DamageEnemy(Collision2D other)
    {
        death_tomato enemy = other.gameObject.GetComponent<death_tomato>();
        
        
        if (enemy != null)
        {
            Debug.Log(enemy.name);
            enemy.Die();
        }
    }
}
