using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Threading;

namespace Tests
{
    public class cross_boundary
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("SampleScene");
        }
        [UnityTest]
        public IEnumerator beyondBorder()
        {
            float speed = 1f;
            bool borderBreak = false;
            GameObject tomato = GameObject.FindWithTag("Enemy");
            //tomato.GetComponent<movement_tomato>().walk_speed = speed;

            while (speed < 10000)
            {
                tomato.GetComponent<movement_tomato>().walk_speed = speed;
                if (tomato.transform.position.x < -3 | tomato.transform.position.x > 3)
                {
                    borderBreak = true;
                    break;
                }
                speed++;
                Thread.Sleep(1000);
            }
            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(1f);

            Assert.IsTrue(borderBreak);
            
        }
    }
}
