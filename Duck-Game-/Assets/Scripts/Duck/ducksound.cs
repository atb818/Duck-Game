using UnityEngine;
using System.Collections;

public class ducksound : MonoBehaviour {

    AudioSource audio;
    int repeat;

	void Start () {
        audio = GetComponent<AudioSource>();
        PlaySound();
	}
	
	void Update () {
	
	}

    void PlaySound() {

        audio.Play();

        Invoke("PlaySound", Random.Range(3,7));
    }
}
