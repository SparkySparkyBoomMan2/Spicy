using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class rigid_body
    {

        // A Test behaves as an ordinary method
        [Test]
        public void rigidBodySimplePasses()
        {
            // Use the Assert class to test conditions
            GameObject tomato = GameObject.FindWithTag("Enemy"); //grabs tomato object

            Assert.IsNotNull(tomato.GetComponent<Rigidbody2D>());
        }
    }
}
