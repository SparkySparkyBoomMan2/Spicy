using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GameManager demoPlayer = this.GetComponent<GameManager>();
        demoPlayer.PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        //if key is pressed, stop demo.
        if (Input.anyKey)
        {
            //Switch State to main menu
            StopDemo();
        }
        //else, continue.
    }

    void StopDemo()
    {
        //when any button pushed, stop demo and revert to main menu

    }
}
