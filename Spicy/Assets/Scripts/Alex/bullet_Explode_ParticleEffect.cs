using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Explode_ParticleEffect : MonoBehaviour
{
    void Start()
    {
        //Destroys the particle system after it plays
        //may need to change the second parameter if particle system plays for longer or shorter
        if (this.gameObject.name == "hotSauce_explode(Clone)")
        {
            Debug.Log("Hello there!!!!");
        }
        Destroy(gameObject, 2.5f);
    }

}
