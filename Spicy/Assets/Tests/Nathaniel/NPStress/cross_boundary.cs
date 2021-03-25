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
        public IEnumerator speed_001f()
        {
            float speed = 1f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_010f()
        {
            float speed = 10f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }
        public IEnumerator speed_020f()
        {
            float speed = 20f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_030f()
        {
            float speed = 30f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_040f()
        {
            float speed = 40f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_050f()
        {
            float speed = 50f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_060f()
        {
            float speed = 60f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_070f()
        {
            float speed = 70f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_080f()
        {
            float speed = 80f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_090f()
        {
            float speed = 90f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_100f()
        {
            float speed = 100f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_120f()
        {
            float speed = 120f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_150f()
        {
            float speed = 150f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_200f()
        {
            float speed = 200f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_250f()
        {
            float speed = 250f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_300f()
        {
            float speed = 300f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_350f()
        {
            float speed = 350f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

        [UnityTest]
        public IEnumerator speed_400f()
        {
            float speed = 400f;

            GameObject tomato = GameObject.FindWithTag("Enemy");
            tomato.transform.position = new Vector2(1.5f, -4f);
            tomato.GetComponent<Rigidbody2D>().MovePosition(tomato.transform.position);
            tomato.GetComponent<movement_tomato>().walk_speed = speed;

            Debug.Log("Speed break at:" + speed);
            yield return new WaitForSeconds(2f);

            Assert.IsTrue(tomato.transform.position.y > -4.8);
        }

    }
}
