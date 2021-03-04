using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public void Restart()
    {
        GameManager.instance.Restart();
    }

    public void Quit()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
