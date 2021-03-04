using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Player : MonoBehaviour
{
    //To be called by DamagePlayer so enemy dies
    public void DiePlayer()
    {
        //Destroy(gameObject);
        GameManager.instance.KillPlayer(gameObject);
    }
}
