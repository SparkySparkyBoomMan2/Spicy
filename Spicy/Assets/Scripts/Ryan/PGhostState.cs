using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PGhostState : PassiveGhost
{
    protected PassiveGhost _context;

    public void SetContext(PassiveGhost context)
    {
        Debug.Log("setting context now.");
        this._context = context;
    }

    public abstract void HandleIdle();
    public abstract void HandleChase();

    //CS0208 and CS0214 - managed types cannot have pointers even in unsafe context
    /*public abstract void chase(PassiveGhost* p)
    {
        Debug.Log("already in chase state!");
    }

    virtual void idle(PassiveGhost* p)
    {
        Debug.Log("already in idle state!");
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
