using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuButtons : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public void musicVolUpdate(float vol)
    {
        Debug.Log(vol);
    }
    public void soundVolUpdate(float vol)
    {
        float volume = vol;
        Debug.Log(volume);
    }
    public void OnValueChanged(float vol)
    {
        Debug.Log(vol);
    }
}
