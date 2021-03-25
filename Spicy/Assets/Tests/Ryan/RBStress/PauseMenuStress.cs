using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PauseMenuStress
    {
        bool firstLoad = true;
        //Load the test scene
        [OneTimeSetUp]
        public void LoadScene()
        {
            
            SceneManager.LoadScene("MainMenu");
            //GameObject menuTraverse = GameObject.Find("MainMenu");
            //menuTraverse.GetComponent<GameManager>().Awake();
            //menuTraverse.GetComponent<MainMenuButtons>().PlayGame(); //Object reference not set to an instance of an object???
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PauseMenuStressWithEnumeratorPasses()
        {
            if (firstLoad)
            {
                GameObject mainStart = GameObject.Find("MainMenu");
                mainStart.GetComponent<MainMenuButtons>().PlayGame();
                firstLoad = false;
            }
            
            GameObject menuTraverse = GameObject.FindWithTag("GameController");
            //Need to get state information
            menuTraverse.GetComponent<GameManager>().SwitchState(GameManager.State.PAUSE);
            yield return null; //Minimal frame skip -> highest stress possible
            Assert.IsTrue(menuTraverse.GetComponent<GameManager>().GetState() == GameManager.State.PAUSE);
            menuTraverse.GetComponent<GameManager>().Resume();
            yield return null; //Minimal frame skip -> highest stress possible
            Assert.IsTrue(menuTraverse.GetComponent<GameManager>().GetState() == GameManager.State.PLAY);
            // menuTraverse.GetComponent<GameManager>().Resume();
            // Assert.IsTrue(menuTraverse.GetComponent<GameManager>().GetState() == GameManager.State.PLAY);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

        }

        /*[UnityTest]
        public IEnumerator ResumeStressWithEnumeratorPasses()
        {

            GameObject menuTraverse = GameObject.FindWithTag("GameController");
            //Need to get state information
            //menuTraverse.GetComponent<GameManager>().SwitchState(GameManager.State.PAUSE);
            //Assert.IsTrue(menuTraverse.GetComponent<GameManager>().GetState() == GameManager.State.PAUSE);
            
            menuTraverse.GetComponent<GameManager>().Resume();
            yield return null; //Minimal frame skip -> highest stress possible
            Assert.IsTrue(menuTraverse.GetComponent<GameManager>().GetState() == GameManager.State.PLAY);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

        }*/
    }
}
