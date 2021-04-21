using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_HotSauce_grenade : bullet_default
{
   public override void Start()
    {
        //Overrides the superclass
        // -  This is needed because the hot sauce "grenade" is in a different orientation than other bullets
        // - so a different velocity must be appplied
        rb.velocity = new Vector3(transform.right.y, transform.right.x * -1, transform.right.z) * bulletSpeed;
    }
}
