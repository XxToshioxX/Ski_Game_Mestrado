using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("TimerStarter/Config")]
    public bool TimerStart = false;
    public bool showMilliseconds;

    public float currentSeconds;
    private int timerDefaut;

    [Header("Switch StopWatch")]
    public bool StopWatch = false;
    public Text timerText;

    [Header("Time Values")]
    [Range(0, 60)]
    public int seconds;
    [Range(0, 60)]
    public int minutes;
    [Range (0, 60)] 
    public int hours;

    public Color fontColor;

    
   
   

    void Start()
    {
        if (StopWatch == true)
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
        }
        timerText.color = fontColor;
        timerDefaut = 0;
        timerDefaut +=(seconds + (minutes * 60) + (hours * 60 * 60));
        currentSeconds = timerDefaut;
       
    }
  
    void Update()
    {
        if (TimerStart == true ) 
        {
            StartTimer();
        }
      
    }

    public void StartTimer()
    {
        if (StopWatch == false)
        {
            if ((currentSeconds -= Time.deltaTime) <= 0)
            {
                TimerUp();
            }
            else
            {
                if (showMilliseconds == true)
                {
                    timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss\:fff");
                }
                else
                {
                    timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss");
                }
            }
        }
        else
        {
            if ((currentSeconds += Time.deltaTime) <= 0)
            {
                TimerUp();
            }
            else
            {
                if (showMilliseconds == true)
                {
                    timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss\:fff");
                }
                else
                {
                    timerText.text = TimeSpan.FromSeconds(currentSeconds).ToString(@"hh\:mm\:ss");
                }
            }
        }
    }

    private void TimerUp()
    {
        
        if (showMilliseconds == true)
        {
            timerText.text = "00:00:00:00";
        }
        else
        {
            timerText.text = "00:00:00";
        }
    }

}
