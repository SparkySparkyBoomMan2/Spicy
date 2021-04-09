using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact_HotSauce_launcher : bulletImpact_default
{
    public GameObject bullet;
    
    void Start()
    {
        //Destroys the particle system after it plays
        //may need to change the second parameter if particle system plays for longer or shorter
        //Debug.Log("We are here!!!! YAYAYAYAYAY");
        Destroy(gameObject, 2.5f);
    }

    void OnParticleCollision(GameObject other)
    {      
           //Debug.Log("We are here!!!! YAYAYAYAYAY");
            
           DamageEnemy(other);
    }

    void DamageEnemy(GameObject other)
    {
        death_tomato enemy = other.GetComponent<death_tomato>();
        
        //Debug.Log("We are here!!!! YAYAYAYAYAY --- " + other.tag);
        if (enemy != null)
        {
            Debug.Log("We are here!!!! --- " + enemy.name);
            
            other.GetComponent<CircleCollider2D>().enabled = false;
            enemy.Die();
        }
    }
}
