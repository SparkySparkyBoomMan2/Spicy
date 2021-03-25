using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class spawn_too_many_enemies
    {
        GameObject tomato_guy = Resources.Load("Tomato_Enemy") as GameObject;
        //GameObject spawner_guy = Resources.Load("Spawner") as GameObject;
        
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("SampleScene");
        }


        // Spawns a basic enemy and passes a frame.
        // Does this until count X is reached or failure.
        [UnityTest]
        public IEnumerator spawn_an_enemy_every_frame()
        {
            //GameObject spawner1 = GameObject.Instantiate(spawner_guy);
            
            //spawner1.transform.position = new Vector3(16, 10);
                
            //Spawner spawner = spawner1.AddComponent<Spawner>();

            //GameObject spawn1 = GameObject.FindGameObjectWithTag("Spawner");
            //Spawner spawner = spawn1.AddComponent<Spawner>();

            //GameObject tomato1 = GameObject.FindGameObjectWithTag("Enemy");

            //GameObject spawnerGameObject = new GameObject(name: "Spawner");
            //Spawner spawner = spawnerGameObject.AddComponent<Spawner>();

            //GameObject tomatoGameObject = new GameObject(name: "Tomato_Enemy");
            //Tomato_Enemy = tomatoGameObject.AddComponent<Tomato_Enemy>();

            //spawner.spawnableObjects[0] = tomato_guy;

            int count = 0;
            int total = 100;

            //spawner.transform.position = new Vector3(16, 10);

            while (count < total)
            {
                //spawner.Spawn(0);
                GameObject tomato = GameObject.Instantiate(tomato_guy) as GameObject;

                count++;
                yield return null;
            }

            Assert.IsTrue(count == total);
        }
    }
}