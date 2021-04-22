using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class loadPrefab
    {
        //loads in the scene
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("SampleScene");
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EyeBallLoaded()
        {
            GameObject prefabEye = GameObject.Instantiate(Resources.Load("Assets/Prefabs/Nathaniel/FlyingEyeball.prefab") as GameObject);
            yield return 60;

            Assert.IsNotNull(prefabEye);
        }

        [UnityTest]
        public IEnumerator EyeBallProjectileLoaded()
        {
            GameObject prefabEyeProjectile = GameObject.Instantiate(Resources.Load("Assets/Prefabs/Nathaniel/ProjectileEye.prefab") as GameObject);

            yield return 60;

            Assert.IsNotNull(prefabEyeProjectile);
        }

        [UnityTest]
        public IEnumerator TomatoLoaded()
        {
            GameObject prefabTomato = GameObject.Instantiate(Resources.Load("Assets/Prefabs/Nathaniel/Tomato_Enemy.prefab") as GameObject);

            yield return 60;

            Assert.IsNotNull(prefabTomato);
        }
    }
}
