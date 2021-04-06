using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUIScript : MonoBehaviour
{
    private int waveCount = 1;
    private Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        waveText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetWaveCount()
    {
        waveCount = 1;
    }

    void ShowWaveCount()
    {
        switch (waveCount)
        {
            case 1:
                waveText.text = "Wave: I";
                break;
            case 2:
                waveText.text = "Wave: II";
                break;
            case 3:
                waveText.text = "Wave: III";
                break;
            case 4:
                waveText.text = "Wave: IV";
                break;
            case 5:
                waveText.text = "Wave: V";
                break;

        }
        
    }
}
