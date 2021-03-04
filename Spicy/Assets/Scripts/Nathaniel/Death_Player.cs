using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Player : MonoBehaviour
{

    public void DiePlayer()
    {
        Destroy(gameObject);
        GameManager.instance.GameOver();
    }
}
