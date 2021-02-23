using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // This class controls things like:
    // - UI Elements such as score
    // - Lives
    // - Handling going in and out of menus

    public GameObject Player;
    public GameObject Level;
    public Text text;

    public GameObject panelMainMenu;
    public GameObject panelPauseMenu;
    public GameObject panelLevelPlaying;
    public GameObject panelLevelComplete;
    public GameObject panelWaveInfo;
    public GameObject panelGameOver;

    public GameObject[] Levels;

    public enum State { MENU, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;



    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    void Start()
    {
        SwitchState(State.MENU);
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
                panelMainMenu.SetActive(true);
                break;
            case State.INIT:
                panelLevelPlaying.SetActive(true);
                // Set things like score, lives, etc. here too
                Instantiate(Level); // May need to give a position here as well
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
                panelLevelPlaying.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }
}