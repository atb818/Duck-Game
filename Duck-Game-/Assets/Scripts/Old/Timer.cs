using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

    public float time = 600;
    public string timeText;
    public Text timerText;

    void Start() {
        InvokeRepeating("Countdown", 1, 1);
    }

	void Update () {

        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        
        timerText.text = timeText;

        



    }

    void Countdown() {
        time--;
    }
}
