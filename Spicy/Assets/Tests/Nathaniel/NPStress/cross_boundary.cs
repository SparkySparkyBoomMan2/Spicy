using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
namespace Tests
{
    public class cross_boundary
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("TestNP");
        }
        [UnityTest]
        public IEnumerator beyondBorder()
        {
            GameObject tomato = GameObject.FindWithTag("Enemy");
            GameObject ground = GameObject.FindWithTag("Ground");
            tomato.GetComponent<movement_tomato>().walk_speed = 10f;

            yield return new WaitForSeconds(1f);

            Assert.IsTrue(tomato.transform.position.y > -9.75);
            Debug.Log("Left Test");
        }
    }
}
