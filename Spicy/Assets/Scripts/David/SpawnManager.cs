using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This class handles the management behind the "waves" of spawned enemies in a level
public class SpawnManager : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING, WAITING, COUNTING
    }

    [System.Serializable]
    // Tracks the necessary information needed for each wave, such as which object(s)/enemy to spawn, how many to spawn, and how quickly
    public class Wave
    {
        public string name;             // Wave name
        public Transform spawnedObject; // Could call this enemy instead if only using spawner for enemies  // Can make this into an array of enemy prefabs instead
        public int count;               // Number of spawned enemies
        public float spawnRate;         // How quickly enemies spawn in per wave
    }

    public Wave[] waves;                                    // An array of the number of waves making up the current level
    public Spawner[] spawnPoints;                         // An array of spawn locations (currently using the spawners - may use those instead and shift over some functionality over there)
    private int nextWave = 0;                               // Index into waves to select which wave to spawn
    public float timeBetweenWaves = 5f;                     // Delay time between waves (Can use this for fancy text displaying name of wave before dissapearing)
    private float waveCountdown;                            // Countdown timer for time until next wave starts spawning (only starts counting down once all enemies with tag "Enemy" have been defeated)
    private float timeBetweenSearches = 0.5f;               // This helps alleviate the taxing call in EnemyIsAlive() - mostly for performance boosting. Smaller = more accuracy, larger = better performance
    private SpawnState spawnState = SpawnState.COUNTING;    // Enum defaulting to the current state, which is counting down to the next wave (i.e. wave 1)

    void Start()
    {
        // Error checking to make sure the programmer set up the level correctly
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }

        if (waves.Length == 0)
        {
            Debug.LogError("No waves created");

        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        // While waiting for the player to defeat all the enemies with tag "Enemy", does nothing
        // Once all enemies are defeated, calls waveFinished to begin the next wave
        if (spawnState == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                waveFinished();
            }
            else
            {
                return;
            }
        }

        // If we get to zero and we are not already in the SPAWNING state, then spawn the next wave
        // Otherwise, continue counting down to zero for next wave
        if (waveCountdown <= 0)
        {
            if(spawnState != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    // Coroutine that changes the state to SPAWNING and spawns the next wave
    // Will need to update appropriately if want to select specific enemies to spawn instead of only one option
    // Alternatively, will need to pass off some of this functionality to the Spawner.cs script instead and let it handle spawning
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning " + _wave.name);
        spawnState = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            spawnPoints[i].Spawn(spawnPoints[i].transform, 0);
            //Spawn(_wave.spawnedObject, i);
            yield return new WaitForSeconds(1f/_wave.spawnRate);    // Or can use a delay if want to use that instead, i.e. _wave.delay
        }

        spawnState = SpawnState.WAITING;

        yield break;
    }

    // Function that instantiates the passed object to the location of the parent spawn location
    void Spawn(Transform _spawnedObject, int index)
    {
        Debug.Log("Spawning Enemy " + index);    // + _spawnedObject.name

        Transform _spawnPoint = spawnPoints[index].transform;
        Instantiate(_spawnedObject, _spawnPoint.position, _spawnPoint.rotation);
    }

    // Checks and returns if there are any object tagged with "Enemy" in the scene
    bool EnemyIsAlive()
    {
        timeBetweenSearches -= Time.deltaTime;
        if (timeBetweenSearches <= 0f)
        {
            timeBetweenSearches = 0.5f;
            // All prefab objects will need to have a tag given to them
            // All enemies that are created will need a tag given to them, named "Enemy"
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    // Runs once all enemies from the previous wave have been defeated.
    // Changes the spawn state back to COUNTING, increments to the next wave, and if the last wave is complete, calls levelComplete()
    void waveFinished()
    {
        Debug.Log("Wave completed");

        spawnState = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        nextWave++;

        // This runs when all waves are completed. Go to level won scenario
        if (nextWave > waves.Length - 1)
        {
            Debug.Log("All waves complete");
            // levelComplete();
            // Logic for transitioning to level complete state -- goes back to level select state, next level unlocked
        }
    }
}
