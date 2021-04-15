using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DemoManager : MonoBehaviour
{
    //private bool firstPass = true;
    public bool demoModeActive = true;
    private GameObject demoPlayer;      //to control operation of demo mode
    private GameObject mainMenuHandler;  //needs to be transform to disable?

    private static DemoManager dInstance = null;
    
    public static DemoManager DInstance
    {
        get
        {
            return dInstance;
        }
    }

    void Awake()
    {
        if (dInstance == null)
        {
            dInstance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("demo instance created.");
        }
        else if (dInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
           
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (demoModeActive) {
            demoPlayer = GameObject.FindWithTag("GameController");
            demoPlayer.GetComponent<GameManager>().PlayGame();
            //mainMenuHandler = transform.Find("MainMenu").gameObject;
            //mainMenuHandler.SetActive(false);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (demoModeActive)
        {
            if (Input.anyKey)
            {
                //Switch State to main menu
                Debug.Log("Stop The demo.");
                Destroy(gameObject);
                demoPlayer.GetComponent<GameManager>().SwitchState(GameManager.State.MENU);
                
            }
            else
            {
                //just spin... i guess
                //or maybe we can override the player movement script,
                //replacing it with an a* routine that either fails miserably,
                //or epitomizes the concept of "RIP AND TEAR"
            }
        }
           
       
        
        //if key is pressed, stop demo.
        
        //else, continue.
    }

    public void disableDemoFunc()
    {
        demoModeActive = false;
        
    }
}