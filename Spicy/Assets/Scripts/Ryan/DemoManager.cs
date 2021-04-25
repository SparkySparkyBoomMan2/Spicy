using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DemoManager : MonoBehaviour
{
    //private bool firstPass = true;
    //When i mean false, i really mean run just this once
    private static bool demoModeActive = false;
    private static bool demoCheck = false;
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
        if (!demoModeActive) {
            demoModeActive = true;
            demoPlayer = GameObject.FindWithTag("GameController");
            demoPlayer.GetComponent<GameManager>().PlayGame();

            //disableDemoFunc();
            //mainMenuHandler = transform.Find("MainMenu").gameObject;
            //mainMenuHandler.SetActive(false);
            GameManager.instance.panelMainMenu.SetActive(false);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!demoCheck)
        {
            if (Input.anyKey)
            {
                //Switch State to main menu
                demoCheck = true;
                Debug.Log("Stop The demo.");
                demoPlayer.GetComponent<GameManager>().SwitchState(GameManager.State.MENU);
                Destroy(gameObject);                
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

    /*if (demoActive)
        {
            //GameObject.FindGameObjectWithTag("Demo").GetComponent<DemoManager>().DoDemo();
            demoObject = GameObject.FindWithTag("Demo");
            demoObject.GetComponent<DemoManager>().DoDemo();
    //DemoManager.dInstance.DoDemo();
    disableDemoFunc();
    }*/
}