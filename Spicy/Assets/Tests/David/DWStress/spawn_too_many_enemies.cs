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


            GameObject spawn1 = GameObject.FindGameObjectWithTag("Spawner");
            Spawner spawner = spawn1.AddComponent<Spawner>();

            GameObject tomato1 = GameObject.FindGameObjectWithTag("Enemy");

            yield return new WaitForSeconds(1f);

            //GameObject spawnerGameObject = new GameObject(name: "Spawner");
            //Spawner spawner = spawnerGameObject.AddComponent<Spawner>();

            //GameObject tomatoGameObject = new GameObject(name: "Tomato_Enemy");
            //Tomato_Enemy = tomatoGameObject.AddComponent<Tomato_Enemy>();

            //spawner.spawnableObjects[0] = tomato1;

            int count = 0;
            int total = 100;

            spawner.transform.position = new Vector3(16, 10);

            while (count < total)
            {
                spawner.Spawn(0);
                count++;
                yield return null;
            }

            Assert.IsTrue(count == total);
        }
    }
}