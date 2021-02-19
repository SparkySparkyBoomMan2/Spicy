using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Spawns in the desired prefab to the location of the parent object
public class Spawner : MonoBehaviour
{
    // Could include a variable that goes into the array and selects which object to spawn
    // Would then have to update the spawnObject method
    public GameObject[] spawnableObjects;
    public Transform parent;


    // Add more enum variables according to the different enemies, players, etc. that are made
    [SerializeField]
    private enum spawnable
    {
        PLAYER,
        ENEMY,
    }

    // Start is called before the first frame update
    void Start()
    {
        // Need to add failure-check code
        parent = GetComponent<Transform>();
        SpawnObject();
    }

    // Correctly spawns a prefab of choice to the location of the parent object
    // This may need to be a public method
    void SpawnObject()
    {
        // Will also need to handle things like any sort of spawn animation (i.e. portal, summon, etc.)
        // and destruction of those spawn elements as well
        //Destroy(Instantiate(), delayTime);

        Instantiate(spawnableObjects[(int)spawnable.PLAYER], parent);

    }
}
