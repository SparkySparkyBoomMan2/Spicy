using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class raycast
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
        public IEnumerator raycastWithEnumeratorPasses()
        {
            GameObject tomato = GameObject.FindWithTag("Enemy");

            //Gets the object passed into the movement script
            //Applies it to transform and creates RaycastHit2D for unit test
            //Tests for true if it is touching ground

            Transform grounded = tomato.GetComponent<movement_tomato>().groundDetect1;
            RaycastHit2D groundInfo = Physics2D.Raycast(grounded.position, Vector2.down, .01f);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(2.0f);

            Assert.IsTrue(groundInfo.collider);
        }
    }
}
