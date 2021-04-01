using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DemoManager : MonoBehaviour
{
    //private bool firstPass = true;
    public bool demoModeActive = true;
    public GameObject demoPlayer;

    /*private static DemoManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        if (demoModeActive) {
            demoPlayer = GameObject.FindWithTag("GameController");
            DontDestroyOnLoad(this.gameObject);
            demoPlayer.GetComponent<GameManager>().PlayGame();
            disableDemoFunc();
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.anyKey)
            {
                //Switch State to main menu
                Debug.Log("Stop The demo.");
                
                demoPlayer.GetComponent<GameManager>().SwitchState(GameManager.State.MENU);
            }
            else
            {
                
            }
       
        
        //if key is pressed, stop demo.
        
        //else, continue.
    }

    public void disableDemoFunc()
    {
        demoModeActive = false;
    }
}