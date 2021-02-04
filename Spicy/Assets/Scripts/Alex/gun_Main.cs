using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_Main : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer gunRenderer;
    public float FireRateDelay;
   
    //AllowFire - when true, the gun is allowed to fire
     private bool AllowFire;
    void Start()
    {
        AllowFire = true;
    }

    
    void FixedUpdate()
    {
        AimGun();

        if (Input.GetMouseButton(0) && AllowFire)
        {
            StartCoroutine(FireGun());
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
    // * fire rate is controlled here
    IEnumerator FireGun()
    {
        AllowFire = false;
        
        //Rotation added on z-axis changes angle the "bullet" is instantiated at
        Vector3 rot = transform.GetChild(0).rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 90);

        Instantiate(bullet, new Vector2 (transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.Euler(rot));
        //yield return new WaitForSeconds(.50f);
        yield return new WaitForSeconds(FireRateDelay);
        AllowFire = true;
        
    }

    
}
