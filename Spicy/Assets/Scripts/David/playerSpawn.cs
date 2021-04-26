using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn(int index)
    {
        // Will also need to handle things like any sort of spawn animation (i.e. portal, summon, etc.)
        // and destruction of those spawn elements as well
        //Destroy(Instantiate(), delayTime);

        GameObject nextLife = Instantiate(Player, this.transform.position, this.transform.rotation);
    }
}
