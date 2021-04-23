using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PChase : PGhostState
{
    public override void HandleChase()
    {
        Debug.Log("PChase state is currently handling the chase behavior.");

        //spin in loop while distance to player is less than threshold

        //just keep on chasin'

        //if distance exceeds threshold, transition to Idle state
        this._context.TransitionTo(new PIdle());
    }

    public override void HandleIdle()
    {
        //Give this to the idle state?
        Debug.Log("PChase handling idle! not good!");
    }


    //CS0208 and CS0214 - managed types cannot have pointers even in unsafe context
    /*public void doIdle(PassiveGhost *p)
    {
        Debug.Log("Going from Chase to Idle");
        p->setCurrent(new PIdle());
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
