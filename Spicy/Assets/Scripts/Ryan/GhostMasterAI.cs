using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostMasterAI : MonoBehaviour
{
    
    protected Transform target;

    protected float speed = 200f;
    public float nextWaypointDistance = 2f;

    protected Transform enemyGFX;

    protected Path path; //path to follow
    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    protected Seeker seeker;
    protected Rigidbody2D rb;
    protected Transform dest;
    public GameObject playerLoc;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyGFX = GetComponent<Transform>();
        playerLoc = GameObject.Find("Player Variant");
        if(playerLoc != null)
        {
            dest = playerLoc.GetComponent<Transform>();
        }
            
        target = dest;
        
        //Specialize
        //Instantiate(new PassiveGhost(new PIdle()), new Vector3(0, 0, 0), Quaternion.identity);
        //var context = new PassiveGhost(new PIdle());
        //context.RequestIdle();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //for damage against player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Collide with Enemy");
            GameManager.instance.KillPlayer(playerLoc);
            //Debug.Log("Damage Player called");
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (playerLoc != null)
        {
            dest = playerLoc.GetComponent<Transform>();
            target = dest;
        }
        

        //To prevent erroneous runtime errors
        if (path == null)
            return;

        //
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } 
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //Make sure no more force if where ghost needs to be
        if (!reachedEndOfPath)
        {
            rb.AddForce(force);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);


        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x <= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    
}
