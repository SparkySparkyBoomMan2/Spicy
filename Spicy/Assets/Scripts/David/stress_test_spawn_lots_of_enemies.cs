using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stress_test_spawn_lots_of_enemies : MonoBehaviour
{
    public Spawner spawner;

    private int count = 0;
    private int total = 10000;
    private bool haveChecked = false;
    private int i = 1;

    // Update is called once per frame
    void Update()
    {
        if (count < total)
        {
            spawner.Spawn(0);
            count++;
            if (count % 100 == 0)
            {
                Debug.Log("Current number: " + i + "00");
                i++;
            }
        }
        else if (count >= total && Time.timeScale == 0f)
        {
            Debug.Log("Total number of spawned units: " + count);
            haveChecked = true;
        }

        if (!haveChecked && Time.timeScale == 0f)
        {
            // Ran test, took ~10-15 minutes, total number of spawned units was: 3305
            Debug.Log("Total number of spawned units: " + count);
            haveChecked = true;
        }
    }
}
