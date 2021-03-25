using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
  
    public class bulletStress
    {
        

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("APTestScene");
        }


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator tooManyBullets()
        {

            yield return new MonoBehaviourTest<MyMonoBehaviourTest>();
            
        }

    }

            public class MyMonoBehaviourTest : gun_default, IMonoBehaviourTest
        {
            GameObject gun {
                get {return GameObject.FindGameObjectWithTag("Gun"); }
            }
            GameObject Mybullet {
                get {return (GameObject) Resources.Load("HotSuace_bullet"); }
            }

            private int frameCount;
            public int otherCount;
            public int frameRate;
            public bool IsTestFinished
            {
                //eventually will stop if nothing happens, test is good
                get { 
                    return frameCount > 800; 
                    }
            }

            void Update()
            {
                
                frameRate = (int)(1f / Time.smoothDeltaTime);
            }



            void FixedUpdate()
            {
                if (frameCount < 2) otherCount = 0;
                else if (frameCount % 200 == 0) otherCount++;

                
                if (frameCount > 5) Assert.IsTrue(frameRate >= 25);

                Debug.Log("fps: " + frameRate);

                frameCount++;
                
                Vector3 rot = gun.transform.GetChild(0).rotation.eulerAngles;
                rot = new Vector3(rot.x, rot.y, rot.z + 90);
                gun.transform.rotation = Quaternion.Euler(0, 0, -90);


                Instantiate(Mybullet, new Vector2 (gun.transform.GetChild(0).position.x, gun.transform.GetChild(0).position.y), Quaternion.Euler(rot));                
               
                for (int i = 0; i < otherCount; i++){
                    Instantiate(Mybullet, new Vector2 (gun.transform.GetChild(0).position.x, gun.transform.GetChild(0).position.y), Quaternion.Euler(rot));
                }
            


                /*GameObject []allBullets = GameObject.FindGameObjectsWithTag("Bullet");
                foreach(GameObject bullet in allBullets){
                    //Debug.Log("bullet: " + bullet.transform.position.y + " --- gun: " +  gun.transform.position.y);    
                    //This will be false if the bullet passes through the map
                    Assert.IsTrue(bullet.transform.position.y > gun.transform.position.y - 10);        
                           
                }*/
            }
        }

}