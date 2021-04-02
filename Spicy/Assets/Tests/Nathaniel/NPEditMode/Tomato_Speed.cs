using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tomato_Speed
    {
        [Test]
        public void isSpeed1f()
        {
            float sp = 1.0f;
            GameObject tomato = GameObject.FindWithTag("Enemy"); //grabs tomato object

            Assert.That(tomato.GetComponent<movement_tomato>().walk_speed == sp);
        }
    }
}
