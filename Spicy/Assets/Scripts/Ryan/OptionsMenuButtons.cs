using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuButtons : MonoBehaviour
{
    public void MainMenu()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameManager.instance.MainMenu();
        } else
        {
            GameManager.instance.OptionsToPause();
        }
        
    }

    public void OnValueChanged(float vol)
    {
        Debug.Log(vol);
    }
}
