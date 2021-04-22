using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class movement
    {
        //loads in the scene
/*        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("SampleScene");
        }*/

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator moves()
        {
            GameObject tomato = GameObject.FindWithTag("Enemy"); //grabs tomato object
            tomato.GetComponent<movement_tomato>().RunMovement(); //set speed
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return 60;

            Assert.IsTrue(tomato.GetComponent<movement_tomato>().RunMovement());
        }
    }
}
