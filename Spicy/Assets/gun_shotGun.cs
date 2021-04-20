using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_shotGun : gun_default
{    

    //Coroutine to "shoot" gun
    // * new bullet is instantiated
    // * fire rate is used to wait between shots
    
    public override IEnumerator FireGun()
    {
        AllowFire = false;
        animator.SetBool("isFiring", true);

        Vector3 rot = transform.GetChild(0).rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);
        //rot = new Vector3(rot.x, rot.y, rot.z);

        Instantiate(bullet, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rot));
        
        yield return new WaitForSeconds(FireRateDelay);
        animator.SetBool("isFiring", false);
        AllowFire = true;

        
    }

    //Coroutine to reload gun
    // * sets a parameter of the attatched animator to true (play animation)
    // * waits for animation to complete, then sets it to false
    //public override IEnumerator Reload()
    //{
        /*
        isReloading = true;
        animator.SetBool("isLauncherReload", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isLauncherReload", false);
        yield return new WaitForSeconds(.5f);
        isReloading = false;
        */
    //}

}