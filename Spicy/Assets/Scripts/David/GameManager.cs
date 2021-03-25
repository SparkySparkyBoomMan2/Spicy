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

    public GameObject Player;
    public float respawnDelay = 2f;
    public int lives = 3;
    public int level = 1;
    private bool spawningPlayer = false;
    private bool isRespawning = false;

    public GameObject panelMainMenu;
    public GameObject panelPauseMenu;
    public GameObject panelOptionsMenu;
    public GameObject panelLevelComplete;
    public GameObject panelGameOver;
    // public GameObject panelWaveInfo;                 // When implemented, will appear at the beginning of the level to show briefly the number of waves
    // public GameObject panelLevelPlaying;             // This will be for any UI elements overlayed while playing, i.e. lives and maybe score or something

    public GameObject[] Levels;

    public enum State { MENU, OPTIONS, INIT, PLAY, PAUSE, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
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

    public void Restart()
    {
        level -= 1;
        SwitchState(State.INIT);
    }

    public void Resume()
    {
        SwitchState(State.PLAY);
    }

    public void KillPlayer(GameObject player)
    {
        Transform playerTransform = player.transform;
        Destroy(player);
        lives -= 1;
        Debug.Log("Lives remaining: " + lives);
        if (lives >= 0 && !isRespawning)
        {
            StartCoroutine(Respawn(playerTransform));
        }
        else
        {
            SwitchState(State.GAMEOVER);
        }
    }

    public IEnumerator Respawn(Transform transform)
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);
        GameObject newPlayer = Instantiate(Player, transform);
        newPlayer.transform.parent = null;
        isRespawning = false;
    }

    public IEnumerator LoadLevelCoroutine()
    {
        spawningPlayer = true;
        yield return new WaitForSeconds(0.2f);
        Transform playerSpawnPoint = GameObject.FindGameObjectWithTag("Player Spawn Location").transform;
        playerSpawnPoint.parent = null;
        GameObject newPlayer = Instantiate(Player, playerSpawnPoint);
        //newPlayer.transform.parent = null;
        spawningPlayer = false;
    }

    public void MainMenu()
    {
        SwitchState(State.MENU);
    }

    public void Options()
    {
        SwitchState(State.OPTIONS);
    }

    public void LevelComplete()
    {
        SwitchState(State.LEVELCOMPLETED);
    }

    public void SwitchState(State newState)
    {
        EndState();
        _state = newState;
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
                panelOptionsMenu.SetActive(true);
                break;
            case State.INIT:
                //panelLevelPlaying.SetActive(true);
                // Set things like score, lives, etc. here too
                //Instantiate(Level); // May need to give a position here as well
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                // Turn on panel for HUD UI stuff, i.e. if there are lives or a score, activate them now
                // Player respawn here
                break;
            case State.PAUSE:
                panelPauseMenu.SetActive(true);
                break;
            case State.LEVELCOMPLETED:
                Time.timeScale = 0f;
                panelLevelComplete.SetActive(true);
                break;
            case State.LOADLEVEL:
                // Load stuff into level -- may not need this step if we are using different scenes to house the various levels, but maybe for additional players, etc.
                if (!spawningPlayer)
                {
                    StartCoroutine(LoadLevelCoroutine());
                }
                lives = 3;
                SwitchState(State.PLAY);
                break;
            case State.GAMEOVER:
                Time.timeScale = 0f;
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
                if (Input.GetKey(KeyCode.Escape))
                {
                    Time.timeScale = 0f;
                    SwitchState(State.PAUSE);
                }
                break;
            case State.PAUSE:
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
                panelOptionsMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.PAUSE:
                panelPauseMenu.SetActive(false);
                Time.timeScale = 1f;
                break;
            case State.LEVELCOMPLETED:
                Time.timeScale = 1f;
                panelLevelComplete.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                Time.timeScale = 1f;
                //panelLevelPlaying.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }

    public State GetState()
    {
        return _state;
    }
}