/* MVWaitTime.cs
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

// This edit mode test tests if the attack wait time for the octocat is equal to 3
namespace Tests
{
    public class MVWaitTime
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestWaitTime()
        {
            // Use the Assert class to test conditions
            GameObject octocat = GameObject.Find("Octocat");
            Assert.AreEqual(octocat.GetComponent<Octocat>().attackWaitTime, 3f);
        }
    }
}
