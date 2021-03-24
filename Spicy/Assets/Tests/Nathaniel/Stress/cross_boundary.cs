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

            GameObject tomato = GameObject.Find("Tomato_Enemy");
            Assert.That(tomato.transform.position.x < -9.75);
        }
        [UnityTest]
        public IEnumerator right()
        {

            yield return 100;

            GameObject tomato = GameObject.Find("Tomato_Enemy");
            Assert.That(tomato.transform.position.x > 27.75);
        }
    }
}
