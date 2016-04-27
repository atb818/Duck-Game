using UnityEngine;
using System.Collections;

public class ducksound : MonoBehaviour {

    public AudioSource audio;
    int repeat;

	void Start () {
        PlaySound();
	}
	
	void Update () {
	
	}

    void PlaySound() {

        audio.Play();

        Invoke("PlaySound", Random.Range(3,7));
    }
}
