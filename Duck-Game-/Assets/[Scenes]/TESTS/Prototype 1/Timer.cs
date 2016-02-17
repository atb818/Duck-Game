using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    int time = 6;

    public GameObject words;
    Text timeRemain;

    public AudioSource bell;

    bool soundPlayed;

    void Start () {
        soundPlayed = false;
        InvokeRepeating("Countdown", 0f, 1f);
        timeRemain = words.GetComponent<Text>();
    }
	
	
	void Update () {
        timeRemain.text = " " + time;
        if(time == 0)
        {
            if (!soundPlayed)
            {
                bell.Play();
                soundPlayed = true;
            }
            CancelInvoke();
        }
    }

    void Countdown()
    {
        time--;
    }
}
