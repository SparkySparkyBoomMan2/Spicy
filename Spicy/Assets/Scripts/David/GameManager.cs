using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // This class controls things like:
    // - UI Elements such as score
    // - Lives
    // - Handling going in and out of menus

    // public GameObject Player;
    public int lives = 3;
    public int level = 1;

    public GameObject panelMainMenu;
    public GameObject panelPauseMenu;
    public GameObject panelOptionsMenu;
    public GameObject panelLevelComplete;
    public GameObject panelGameOver;
    // public GameObject panelWaveInfo;                 // When implemented, will appear at the beginning of the level to show briefly the number of waves
    // public GameObject panelLevelPlaying;             // This will be for any UI elements overlayed while playing, i.e. lives and maybe score or something

    public GameObject[] Levels;

    public enum State { MENU, OPTIONS, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;

    // Sets up the singleton instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start()
    {
        SwitchState(State.MENU);
    }

    // This function is the equivalent of the "MainMenuButtons.cs" PlayGame function. Get the functionality over there
    // This will eventually lead to the map UI where we can select which level we want to play, but for now it will just setup and run the first level
    public void PlayGame()
    {
        level = 1;
        SwitchState(State.INIT);
    }

    public void GameOver()
    {
        // When player runs out of lives and dies
    }

    public void SwitchState(State newState)
    {
        EndState();
        BeginState(newState);
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                if (SceneManager.GetActiveScene().buildIndex != 0)
                {
                    SceneManager.LoadScene(0);
                }
                panelMainMenu.SetActive(true);
                break;
            case State.OPTIONS:
                break;
            case State.INIT:
                //panelLevelPlaying.SetActive(true);
                // Set things like score, lives, etc. here too
                //Instantiate(Level); // May need to give a position here as well
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelComplete.SetActive(true);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;
        }

    }

    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.OPTIONS:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                // if lives > 0, instantiate the player and subtract 1 life else, game over
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMainMenu.SetActive(false);
                break;
            case State.OPTIONS:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelComplete.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                //panelLevelPlaying.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }
}