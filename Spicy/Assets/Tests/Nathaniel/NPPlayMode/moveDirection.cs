using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class moveDirection
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
        public IEnumerator moves_to_the_right()
        {
            GameObject tomato = GameObject.FindWithTag("Enemy"); //grabs tomato object
            tomato.GetComponent<movement_tomato>().runMovement(); //set speed
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(1f);

            Assert.That(tomato.GetComponent<movement_tomato>().runMovement() == 1);
        }
        [UnityTest]
        public IEnumerator moves_to_the_left()
        {
            GameObject tomato = GameObject.FindWithTag("Enemy"); //grabs tomato object
            tomato.GetComponent<movement_tomato>().runMovement(); //set speed
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(1f);

            Assert.That(tomato.GetComponent<movement_tomato>().runMovement() == 0);
        }
    }
}
