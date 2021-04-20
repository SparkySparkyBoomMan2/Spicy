using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{
    public void Resume()
    {
        GameManager.instance.Resume();
    }

    public void Restart()
    {
        GameManager.instance.Restart();
    }

    public void Options()
    {
        GameManager.instance.Options();
    }

    public void ToMainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public void Quit()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
