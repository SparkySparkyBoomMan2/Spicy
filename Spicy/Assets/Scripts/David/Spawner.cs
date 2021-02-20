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

    // Start is called before the first frame update
    void Start()
    {
        // Need to add failure-check code
        //parent = GetComponent<Transform>();
    }

    // Correctly spawns a prefab of choice to the location of the parent object
    // This may need to be a public method
    public void Spawn(int index)
    {
        // Will also need to handle things like any sort of spawn animation (i.e. portal, summon, etc.)
        // and destruction of those spawn elements as well
        //Destroy(Instantiate(), delayTime);

        Instantiate(spawnableObjects[index], this.transform);

    }

    // Function that instantiates the passed object to the location of the parent spawn location
    public void Spawn(Transform _spawnedObject, int index)
    {
        Debug.Log("Spawning Enemy " + index);    // + _spawnedObject.name

        Transform _spawnPoint = _spawnedObject;
        Instantiate(spawnableObjects[index], _spawnPoint.position, _spawnPoint.rotation);
    }
}
