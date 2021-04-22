using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_shotGun : gun_default
{    

    //Coroutine to "shoot" gun
    // * new projectile is instantiated
    // * fire rate is used to wait between shots
    
    //Overrided from base class to have multiple spawn points and fire multiple projectiles
    public override IEnumerator FireGun()
    {
        AllowFire = false;
        animator.SetBool("isFiring", true);

        //Get the rotation of the child object (which is the fire point)
        Vector3 rot = transform.GetChild(0).rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);

        //Determines the direction each projectile from the shotgun will take, relative to straightforward
        Vector3 rotUp = new Vector3(rot.x, rot.y, rot.z + 15);
        Vector3 rotDown = new Vector3(rot.x, rot.y, rot.z - 15);
        Vector3 rotUp2 = new Vector3(rot.x, rot.y, rot.z + 30);
        Vector3 rotDown2 = new Vector3(rot.x, rot.y, rot.z - 30);
     

        //Instantiates each projectile, acting like spread from a shotgun pellet in this case
        Instantiate(projectile, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rotDown));
        Instantiate(projectile, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rotUp));
        Instantiate(projectile, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rotDown2));
        Instantiate(projectile, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rotUp2));
        
        yield return new WaitForSeconds(FireRateDelay);
        animator.SetBool("isFiring", false);
        AllowFire = true;

        
    }

}