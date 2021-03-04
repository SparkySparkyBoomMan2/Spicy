using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteButtons : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public void Options()
    {
        GameManager.instance.Options();
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
