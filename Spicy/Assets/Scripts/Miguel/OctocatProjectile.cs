using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctocatProjectile : MonoBehaviour
{
    public float speed = 5f;        // Speed of projectile
    public Rigidbody2D rb;          // Rigidbody of projectile
    private float time;             // Time elapsed for projectile
    public float despawnTime = 3f;  // Time in which projectile will be despawned
    public GameObject impact;       // Animation object that will play on impact with player

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;     // Move projectile
        time = despawnTime;                     // Set despawn time for projectile
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If projectile collides with player:
        //     Instatiate impact animation
        //     Call temporary respawn while final level and game manager are missing
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(impact, transform.position, transform.rotation);
            Destroy(impact);

            // Won't work until boss level is implemented
            // My intuition is that the GameManager is needed
            /*GameObject player = GameObject.Find("Player Variant");
            if(player != null)
            {
                player.GetComponent<Death_Player>().DiePlayer;
            }*/

            // Until then
            Debug.Log("Player Hit");
            collision.gameObject.SetActive(false);
            StartCoroutine(TemporaryRespawn(collision.gameObject));
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
