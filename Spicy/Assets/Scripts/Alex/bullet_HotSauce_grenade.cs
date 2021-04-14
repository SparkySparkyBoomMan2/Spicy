using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_HotSauce_grenade : bullet_default
{
   public override void Start()
    {
        //Makes the bullet have a starting velocity
        //might change depending on instantiated rotation of bullet
        rb.velocity = new Vector3(transform.right.y, transform.right.x * -1, transform.right.z) * BulletSpeed;
    }
}
