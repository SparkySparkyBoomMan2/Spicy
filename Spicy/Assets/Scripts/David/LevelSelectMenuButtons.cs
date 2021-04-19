using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenuButtons : MonoBehaviour
{
    public void LevelOne()
    {
        GameManager.instance.level = 1;
        GameManager.instance.PlayGame();
    }

    public void LevelTwo()
    {
        GameManager.instance.level = 2;
        GameManager.instance.PlayGame();
    }

    public void LevelThree()
    {
        GameManager.instance.level = 3;
        GameManager.instance.PlayGame();
    }

    public void LevelFour()
    {
        GameManager.instance.level = 4;
        GameManager.instance.PlayGame();
    }

    public void MainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameManager.instance.MainMenu();
        }
        else
        {
            GameManager.instance.OptionsToPause();
        }

    }
}
