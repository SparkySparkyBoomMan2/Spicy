/* MVAttack.cs
 * 
 * Miguel Villanueva
 * CS 383
 * April 20, 2021
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// This play mode test tests if the final boss can attack
namespace Tests
{
    public class MVAttack
    {
        // 	Identifies methods to be called once prior to any child tests.
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("MVOctocatTestScene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestAttack()
        {
            GameObject octocat = GameObject.Find("Octocat");
            if (octocat != null)
            {
                octocat.GetComponent<Octocat>().Attack();
                //GameObject projectile = octocat.GetComponent<Octocat>().projectile;
                GameObject projectile = GameObject.Find("OctocatProjectile(Clone)");
                // Use the Assert class to test conditions.
                // Use yield to skip a frame.
                yield return 60;
                Assert.IsNotNull(projectile);   // Could maybe also use 'Assert.That' on Attack() function
            }
        }
    }
}
