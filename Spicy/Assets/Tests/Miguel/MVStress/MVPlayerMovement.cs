using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class MVPlayerMovement
    {
        // 	Identifies methods to be called once prior to any child tests.
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("MVTestMovementScene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DashOutOfBounds()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Movement>().dashSpeed = 10000;
            player.GetComponent<Movement>().Dash(0, -1);  // Dash Down
            yield return 60;
            Assert.IsTrue(player.transform.position.y > -6);
        }
    }
}
