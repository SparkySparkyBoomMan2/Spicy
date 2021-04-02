using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_default : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer gunRenderer;
    public Animator animator;
    public float FireRateDelay;
   
    //AllowFire - when true, the gun is allowed to fire
    //isReloading - when true, gun is reloading
     protected bool AllowFire;
     protected bool isReloading;

    protected float startTime;


    void Start()
    {
        AllowFire = true;
        isReloading = false;
    }

    
    void FixedUpdate()
    {
        AimGun();

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Trying to fire, and AllowFire == ["+ AllowFire + "] --- isReloading: " + isReloading);
            Debug.Log("Time: " + Time.time + " ----- startTime: " + startTime);
            if ((!AllowFire || isReloading) && Time.time - startTime > 5) 
            {
                AllowFire = true;
                isReloading = false;
            }
        }

        if (Input.GetMouseButton(0) && AllowFire &&!isReloading)
        {  
            startTime = Time.time;  
            StartCoroutine(FireGun());
        }
        else if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

    }

    //Moves gun to aim towards mouse pointer
    void AimGun()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        var objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //Flips gun across y axis if mouse cursor crosses the gun's y axis
        if (transform.rotation.z > .7f || transform.rotation.z < -.7f)
        {
            gunRenderer.flipY = true;
        }
        else
        {
            gunRenderer.flipY = false;
        }
    }

    //Coroutine to "shoot" gun
    // * new bullet is instantiated
    // * fire rate is used to wait between shots
    public virtual IEnumerator FireGun()
    {
        AllowFire = false;
        //Debug.Log("FIring gun");
        //Rotation added on z-axis changes angle the "bullet" is instantiated at
        Vector3 rot = transform.GetChild(0).rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 90);

        Instantiate(bullet, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rot));
        yield return new WaitForSeconds(FireRateDelay);
        AllowFire = true;
    }

    //Coroutine to reload gun
    // * sets a parameter of the attatched animator to true (play animation)
    // * waits for animation to complete, then sets it to false
    public virtual IEnumerator Reload()
    {
        //isReloading = true;
        //animator.SetBool("isLauncherReload", true);
        //yield return new WaitForSeconds(1f);
        //animator.SetBool("isLauncherReload", false);
        yield return new WaitForSeconds(.5f);
        //isReloading = false;
    }

    
}
