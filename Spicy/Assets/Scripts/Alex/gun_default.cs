using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_default : MonoBehaviour
{
    // bullet - GameObject for bullet which is attatched to script in inspector
    // gunRenderer - SpriteRenderer for gun which script is attatched to 
    // animator - Animation controller for specifc weapon attatched to script
    // FireRateDelay - Time in seconds which weapon will wait after firing each bullet

    //AllowFire - when true, the gun is allowed to fire
    //isReloading - when true, gun is reloading

    //startTime - used to check if AllowFire and isReloading have been set for too long
    // - (used to fix issue where these would be false, and then gun would be set inactive)
    public GameObject bullet;
    public SpriteRenderer gunRenderer;
    public Animator animator;
    public float FireRateDelay;
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
            // If AllowFire or isReloading is set, and it has been more than 5 seconds since the FireGun coroutine has been called
            // - then set both to true
            // - fixes issue where these variables stay false when gun is set inactive
            if ((!AllowFire || isReloading) && Time.time - startTime > 5) 
            {
                AllowFire = true;
                isReloading = false;
            }
        }

        //If fire button is pressed, and we are not violating the fire rate, and the player is not reloading, then fire weapon
        if (Input.GetMouseButton(0) && AllowFire &&!isReloading)
        {  
            startTime = Time.time;  
            StartCoroutine(FireGun());
        }
        //If weapon reloads, then reload weapon
        else if (Input.GetKey(KeyCode.R))
        {
            //StartCoroutine(Reload());
        }

    }

    //Moves gun to aim towards mouse pointer consistently
    void AimGun()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        var objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //Vector3 currentRotation = transform.localRotation.eulerAngles;

        //Flips gun across y axis if mouse cursor crosses the gun's y axis
        //Flips localScale of object, so it affects the children as well
        /*
        if ((transform.rotation.z > .7f || transform.rotation.z < -.7f) && transform.localScale.y > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1,transform.localScale.z);
        }
        else if ((transform.rotation.z < .7f && transform.rotation.z > -.7f))
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y) ,transform.localScale.z);
        }
        */

        //Get the player's gameobject and store it
        GameObject player = GameObject.Find("Player Variant");

        if (player != null)
        {
            //If the player is not null, get the movement script and store it
            var script = player.GetComponent<Movement>();
            if (script != null)
            {

                //If the script is not null, then check the "script.side" variable to see what direction the player is facing, and flip the gun accordingly
                if (script.side > 0 && transform.localScale.y < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y) ,transform.localScale.z);

                }
                else if (script.side < 0 && transform.localScale.y > 0 )
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1,transform.localScale.z);
                }


                //Lock the rotation of the gun so the player cannot fire directly behind them
                //i.e. the player must shoot in the direction they move for the most part
                //(still rough)

                if (script.side > 0)
                {
                    angle = Mathf.Clamp(angle, -115, 115);
                }
                else if (script.side < 0)
                {   
                    bool isNeg = false;
                    if (angle < 0)
                        isNeg = true;

                    angle = Mathf.Clamp(Mathf.Abs(angle), 65, 180);

                    if (isNeg)
                        angle *= -1;
                }
                
                //Here is where the rotation for the gun is actually set
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                //Debug.Log("angle is: " + angle);
            }
        }
    }

    //Coroutine to "shoot" gun
    // * new bullet is instantiated
    // * fire rate is used to wait between shots
    public virtual IEnumerator FireGun()
    {//
        AllowFire = false;
        animator.SetBool("isFiring", true);
        //Debug.Log("FIring gun");
        //Rotation added on z-axis changes angle the "bullet" is instantiated at
        Vector3 rot = transform.GetChild(0).rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);

        Instantiate(bullet, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rot));
        yield return new WaitForSeconds(FireRateDelay);
        animator.SetBool("isFiring", false);
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
        yield return new WaitForSeconds(0f);
        //isReloading = false;
    }

    
}
