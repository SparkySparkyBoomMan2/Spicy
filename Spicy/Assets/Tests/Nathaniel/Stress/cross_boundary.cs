using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class cross_boundary
    {

        [UnityTest]
        public IEnumerator left()
        {

            yield return 100;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            Assert.That(tomato.transform.position.y > -9.75);
            Debug.Log("Left Test");
        }
        [UnityTest]
        public IEnumerator right()
        {

            yield return 100;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            Assert.That(tomato.transform.position.y < 27.75);
            Debug.Log("Right Test");
        }
    }
}
