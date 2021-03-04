/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class right_left_movement
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Right()
        {
            var GameObject = new GameObject();
            var tomato = GameObject.GetComponent<Tomato_Enemy>();
            Vector2 tomato_position = tomato.getPosition();

            Assert.AreEqual(Vector2.right, tomato_position.x);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Left()
        {
            var GameObject = new GameObject();
            var tomato = GameObject.GetComponent<Tomato_Enemy>();
            Vector2 tomato_position = tomato.getPosition();

            Assert.AreEqual(Vector2.left, tomato_position.y);
            yield return null;
        }
    }
}
*/