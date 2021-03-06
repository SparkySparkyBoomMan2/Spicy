﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.instance.PlayGame();
    }

    public void Options()
    {
        GameManager.instance.SwitchState(GameManager.State.OPTIONS);
    }

    public void QuitGame()
    {
        Debug.Log("Application quit.");
        Application.Quit();
    }
}
