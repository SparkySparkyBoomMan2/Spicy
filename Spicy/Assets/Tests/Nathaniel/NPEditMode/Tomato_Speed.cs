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
            bool isSpeedTrue = false;
            GameObject tomato = GameObject.FindWithTag("Enemy"); //grabs tomato object
            if(tomato.GetComponent<movement_tomato>().walk_speed == 1f)
            {
                isSpeedTrue = true;
            }

            Assert.IsTrue(isSpeedTrue);
        }
    }
}
