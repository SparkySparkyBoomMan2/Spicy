using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLevel2 : SpawnManager
{
    // Start is called before the first frame update
    void Awake()
    {
        onSetup();
    }

    public override void onSetup()
    {
        // Setup the waves and mini waves here
        timeBetweenWaves = 3f;
    }

}
