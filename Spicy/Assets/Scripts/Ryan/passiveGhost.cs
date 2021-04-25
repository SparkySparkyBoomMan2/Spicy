using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveGhost : GhostMasterAI
{

    //Get a state descriptor
    private PGhostState _state = null;



    //Not sure if i need this...
    //Default to idle state?
    /*public PassiveGhost(PGhostState state)
    {
        Debug.Log("Constructor entered.");
        this.TransitionTo(state);
    }*/



    public void TransitionTo(PGhostState state)
    {
        Debug.Log("Transitioning state.");
        this._state = state;
        this._state.SetContext(this);
    }

    //The context delegates part of its behavior to the current State object.
    public void RequestIdle()
    {
        Debug.Log("Request to Idle made.");
        this._state.HandleIdle();
    }

    public void RequestChase()
    {
        Debug.Log("Request to Chase made.");
        this._state.HandleChase();
    }


    //CS0208 and CS0214 - managed types cannot have pointers even in unsafe context
    /*public void setCurrent(PGhostState *s)
    {
        current = s;
    }
    
    public void chase()
    {
        current->chase(this);
    }

    public void idle()
    {
        current->idle(this);
    }*/



    //for damage against player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Collide with Enemy");
            GameManager.instance.KillPlayer(playerLoc);
            //Debug.Log("Damage Player called");
        }
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    //MAY NEED TO PUT BELOW IN EACH CONCRETE STATE
    // Update is called once per frame
    public override void FixedUpdate()
    {
        if (playerLoc != null)
        {
            dest = playerLoc.GetComponent<Transform>();
            target = dest;
        }


        if (path == null)
        {
            return;
        }

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
        Vector2 force = direction * speed * 0.5f * Time.deltaTime;

        if(!reachedEndOfPath)
        {
            rb.AddForce(force);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(rb.velocity.x <= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
