using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact_HotSauce_launcher : bulletImpact_default
{
    void OnParticleCollision(GameObject other)
    {      
        //This will get called for each particle of "hot sauce" which spawns from this particle effect
        //Each particle will call the DamageEnemy function (making this a very over-powered weapon)
        DamageEnemy(other);
    }

    // Had to redefine this here as I couldn't get it to work with the function in the bullet
    void DamageEnemy(GameObject other)
    {

        //When any hot sauce particle collides with a tomato enemy
        if (other.name == "Tomato_Enemy(Clone)" || other.name == "Tomato_Enemy" )
        {
            //Debug.Log("Hitting tomato");
            //Gets a reference to the tomato enemy script that contaions the "die" function
            //Then if it's not null, call the die function
            death_tomato enemy = other.GetComponent<death_tomato>();
            if (enemy != null)
            {
                other.GetComponent<CircleCollider2D>().enabled = false;
                enemy.Die();
            } 
        }
        //When any hot sauce particle collides with an eyeball enemy
        else if (other.name == "FlyingEyeball(Clone)" || other.name == "FlyingEyeball" )
        {
            //Debug.Log("Hitting eyeball");
            // Only temporary while the eyeball does not have a death handler
            other.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(other.gameObject, 0.05f);
        }
        else if (other.name == "Octocat(Clone)" || other.name == "Octocat")
        //When any hot sauce particle collides with the Octocat Boss
        {
            //Gets a reference to the Octocat script that contaions the "DamageOctocat" function
            //Then if it's not null, call the DamageOctocat function
            //Since it's a boss, not a one-hit kill
            Octocat boss =  other.GetComponent<Octocat>();
            if (boss != null)
            {
                boss.DamageOctocat();
            }
        }

        //Debug.Log("Hitting ---> [" + other.gameObject.name + "]");
    }

}