using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIdle : PGhostState
{
    public override void HandleIdle()
    {

        Debug.Log("PIdle state is currently handling the idle behavior.");
        //Spin in idle loop
        //generate transform near ghost

        //make ghost target transform, and change transform every 5 or so seconds
        //or when ReachedEndOfPath is True

        //find distance between player and ghost.
        //if threshold is passed, transition state to chase.
        this._context.TransitionTo(new PChase());
    }

    public override void HandleChase()
    {
        //Give this to the chase state?
        Debug.Log("Pidle handling chase! not good!");
    }


    //CS0208 and CS0214 - managed types cannot have pointers even in unsafe context
    /*public void doChase(PassiveGhost* p)
    {
        Debug.Log("Going from Chase to Idle");
        p->setCurrent(new PChase());
        //delete this;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
