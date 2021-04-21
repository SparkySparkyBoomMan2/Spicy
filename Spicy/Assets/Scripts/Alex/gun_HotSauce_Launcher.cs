using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_HotSauce_Launcher : gun_default
{    

    //Coroutine to "shoot" gun
    // * new bullet is instantiated
    // * fire rate is used to wait between shots
    
    //Overrided from base class to change the rotation which we instantiate the bullet from the gun is at
    // - this is due to the hot sauce bottle being a different type of bullet than regular
    public override IEnumerator FireGun()
    {
        AllowFire = false;
        animator.SetBool("isFiring", true);

        //Rotation added on z-axis changes angle the "bullet" is instantiated at
        Vector3 rot = transform.GetChild(0).rotation.eulerAngles;

        rot = new Vector3(rot.x, rot.y, rot.z + 90);

        Instantiate(bullet, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rot));
        
        yield return new WaitForSeconds(FireRateDelay);
        animator.SetBool("isFiring", false);
        AllowFire = true;
    }
}