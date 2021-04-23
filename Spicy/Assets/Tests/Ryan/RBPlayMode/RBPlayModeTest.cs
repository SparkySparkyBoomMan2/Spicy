using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class RBPlayModeTest
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("RBGhostTestScene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator RBPlayModeTestForBaseGhost()
        {
            //GameObject prefabGhost = GameObject.Instantiate(Resources.Load("Assets/Prefabs/Ryan/GhostEnemyNew.prefab") as GameObject);
            GameObject prefabGhost = GameObject.Find("GhostEnemyNew");
            yield return 60;
            // Use the Assert class to test conditions.
            Assert.IsNotNull(prefabGhost.GetComponent<GhostMasterAI>().playerLoc);
            // Use yield to skip a frame.
        }

        [UnityTest]
        public IEnumerator RBPlayModeTestForPassiveGhost()
        {
            //GameObject prefabPGhost = GameObject.Instantiate(Resources.Load("Assets/Prefabs/Ryan/PassiveGhostEnemy.prefab") as GameObject);
            GameObject prefabPGhost = GameObject.Find("PassiveGhostEnemy");
            yield return 60;
            // Use the Assert class to test conditions.
            Assert.IsNotNull(prefabPGhost.GetComponent<PassiveGhost>().playerLoc);
            // Use yield to skip a frame.
        }
    }
}
