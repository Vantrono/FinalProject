using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool Win = false;
    
    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        //Stop timer if win
        if (Win)
           return;

        float t = Time.time - startTime;
        // Conversions for time
        string minutes = ((int) t / 60).ToString();
        // Only want two decimals
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

    }

    public void Finish()
    { 
        Win = true;
        timerText.color = Color.yellow;
    }

}
