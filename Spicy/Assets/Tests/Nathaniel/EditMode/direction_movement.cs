using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class direction_movement
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Right()
        {
            Vector2 rightVect = new Vector2(1f, 0);
            var GameObject = new GameObject();
            var tomato = GameObject.GetComponent<Tomato_Enemy>();
            Vector2 tomato_position = tomato.getPosition();

            Assert.AreEqual(rightVect, tomato_position.x);
        }
        [Test]
        public void Left()
        {
            var GameObject = new GameObject();
            var tomato = GameObject.GetComponent<Tomato_Enemy>();
            Vector2 tomato_position = tomato.getPosition();

            Assert.AreEqual(Vector2.right, tomato_position.y);
        }
    }
}
