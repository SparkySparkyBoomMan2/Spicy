using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class hit_points
    {
        [Test]
        public void set_hit_points_2_half()
        {
            //acting on a method
            int finalHitPoints = enemy_hit_points.hitPointCalculator(10, 0.5f);

            //asserting
            Assert.AreEqual(5, finalHitPoints);
            Debug.Log(finalHitPoints);
        }

        [Test]
        public void set_hit_points_2_80()
        {
            //acting on a method
            int finalHitPoints = enemy_hit_points.hitPointCalculator(10, 0.8f);

            //asserting
            Assert.AreEqual(2, finalHitPoints);
            Debug.Log(finalHitPoints);
        }
    }
}
