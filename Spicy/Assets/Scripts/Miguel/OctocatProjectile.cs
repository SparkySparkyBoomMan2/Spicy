/* OctocatProjectile.cs
 * 
 * Miguel Villanueva
 * CS 383
 * April 20, 2021
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OctocatProjectile : MonoBehaviour
{
    public float speed = 5f;        // Speed of projectile
    public Rigidbody2D rb;          // Rigidbody of projectile
    private float time;             // Time elapsed for projectile
    public float despawnTime = 3f;  // Time in which projectile will be despawned
    public GameObject impact;       // Animation object that will play on impact with player
    private bool actualScene;       // For workaround between test level and actual level

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;     // Move projectile
        time = despawnTime;                     // Set despawn time for projectile

        // Workaround for test level and actual level
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Level 4")
            actualScene = true;
        else
            actualScene = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If projectile collides with player:
        //     Instatiate impact animation
        //     Call temporary respawn while final level and game manager are missing
        if (collision.gameObject.tag == "Player")
        {
            GameObject copy = (GameObject) Instantiate(impact, transform.position, transform.rotation);
            Destroy(copy);

            // Won't work until boss level is implemented
            // My intuition is that the GameManager is needed
            /*GameObject player = GameObject.Find("Player Variant");
            if(player != null)
            {
                player.GetComponent<Death_Player>().DiePlayer;
            }*/

            // Until then
            if (!actualScene)
            {
                Debug.Log("Player Hit");
                collision.gameObject.SetActive(false);
                StartCoroutine(TemporaryRespawn(collision.gameObject));
            }
            else
            {
                GameObject player = GameObject.Find("Player Variant");
                GameManager.instance.KillPlayer(player);
            }
        }
    }

    // Temporary respawn in place for lack of game manager and final level
    public IEnumerator TemporaryRespawn(GameObject player)
    {
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // If else statement for despawning octocat's projectiles
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
        else
            time -= Time.deltaTime;
    }
}
