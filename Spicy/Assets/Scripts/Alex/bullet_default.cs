using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_default : MonoBehaviour
{
    // rb - Rigidbody attatched to each bullet
    // bulletImpact - particle system which plays when bullet impacts something
    // buuletSpeed - variable to change how fast bullet travels
    public Rigidbody2D rb;
    public ParticleSystem bulletImpact;
    public float bulletSpeed;

    public virtual void Start()
    {
        //Gives the bullet a starting velocity
        //May change depending on instantiated rotation of bullet
        rb.velocity = new Vector3(transform.right.x * -1, transform.right.y * -1, transform.right.z) * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Bullet is impacting --[" + other.gameObject.tag + "]");

        //If bullet collides with an enemy, damange/kill that enemy
        if (other.gameObject.tag == "Enemy")
        {
            DamageEnemy(other);
        }
        
        //Destroy the bullet, and play the particle effect for bullet impact
        BulletImpact();
    }

    //Instantiates a new "impact" particle effect for the bullet
    // * destroys the bullet, but not particle system
    // * particle system is destroyed in a seperate script
    void BulletImpact()
    {
        Instantiate(bulletImpact, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }

    //If the object collided with is an enemy, damage that enemy
    // * For all enemies besides boss, it is a one hit kill
    //   - Enemies which have their own "die" function will have that called
    //   - Otherwise, this script can just destroy that game object
    // * The Octocat boss damage is held in its own script for now
    public void DamageEnemy(Collision2D other)
    {
        //When the bullet collides with a tomato enemy
        if (other.gameObject.name == "Tomato_Enemy(Clone)" || other.gameObject.name == "Tomato_Enemy" )
        {
            //Debug.Log("Hitting tomato");
            //Gets a reference to the tomato enemy script that contaions the "die" function
            //Then if it's not null, call the die function
            death_tomato tomato = other.gameObject.GetComponent<death_tomato>();
            if (tomato != null)
                tomato.Die();
        }
        //When the bullet collides with an eyeball enemy
        else if (other.gameObject.name == "FlyingEyeball(Clone)" || other.gameObject.name == "FlyingEyeball")
        {
            //Debug.Log("Hitting eyeball");
            //Gets a reference to the eyeball enemy script that contaions the "die" function
            //Then if it's not null, call the die function
            eyeball_patrol eyeball = other.gameObject.GetComponent<eyeball_patrol>();
            if (eyeball != null)
                eyeball.Die();
        }
        //When the bullet collides with a ghost enemy
        else if (other.gameObject.name == "GhostEnemyNew(Clone)" || other.gameObject.name == "GhostEnemyNew")
        {
            GhostMasterAI ghost = other.gameObject.GetComponent<GhostMasterAI>();
            if (ghost != null)
                ghost.Die();
        }
        else if (other.gameObject.name == "Octocat(Clone)" || other.gameObject.name == "Octocat")
        //When the bullet collides with the Octocat Boss
        {
            //Gets a reference to the Octocat script that contaions the "DamageOctocat" function
            //Then if it's not null, call the DamageOctocat function
            //Since it's a boss, not a one-hit kill
            Octocat boss =  other.gameObject.GetComponent<Octocat>();
            if (boss != null)
                boss.DamageOctocat();
        }

        //Debug.Log("Hitting ---> [" + other.gameObject.name + "]");
    }
}
