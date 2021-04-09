using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact_default : MonoBehaviour
{
   

    void Start()
    {
        //Destroys the particle system after it plays
        //may need to change the second parameter if particle system plays for longer or shorter
        //part = GetComponent<ParticleSystem>();
        //collisionEvents = new List<ParticleCollisionEvent>();
        Destroy(gameObject, 2.5f);
    }

   
}
