using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tomato_Enemy_Tests
    {

        //[UnityTest]
        public IEnumerator MoveRight()
        {
            var gameObject = new GameObject();
            var tomato = gameObject.AddComponent<Tomato_Enemy>();


            yield return null;
        }
    }
}
