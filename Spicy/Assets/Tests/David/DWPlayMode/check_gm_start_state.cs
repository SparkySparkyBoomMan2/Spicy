using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class check_gm_start_state
    {
        [OneTimeSetUp]
        public void loadScene()
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        [UnityTest]
        public IEnumerator check_gm_start_state_playmode_test()
        {
            GameObject gm = GameObject.Find("GameManager");

            if (gm != null)
            {
                Assert.AreEqual(gm.GetComponent<GameManager>().GetState(), GameManager.State.MENU);
            }
            yield return null;
        }
    }
}
