using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
namespace Tests
{
    public class enemy_tomato_speed
    {

        [UnityTest]
        public IEnumerator set_speed()
        {
            var GameObject = new GameObject();
            var tomato = GameObject.GetComponent<Tomato_Enemy>();
            
            tomato.setSpeed(999999999);

            Assert.Less(100, Convert.ToInt32(tomato.getPosition().x));

            yield return null;
        }
    }
}
