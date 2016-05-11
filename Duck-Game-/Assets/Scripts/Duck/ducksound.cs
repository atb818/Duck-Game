using UnityEngine;
using System.Collections;

public class ducksound : MonoBehaviour {

    AudioSource audio;
    float repeat;

	void Start () {
        audio = GetComponent<AudioSource>();
        PlaySound();
	}
	
	void Update () {
	
	}

    void PlaySound() {

        audio.Play();

        Invoke("PlaySound", Random.Range(3.0f ,7.0f));
    }
}
