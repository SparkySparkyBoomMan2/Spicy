using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
