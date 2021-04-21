using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class game_manager_lives_check
    {
        // This editmode test checks the time of the spawn manager's wave delay to verify length of time
        [Test]
        public void game_manager_lives_checkSimplePasses()
        {
            int totalLives = GMLivesHelper.returnNumberOfLives();
            Assert.AreEqual(totalLives, 3);
        }
    }
}
