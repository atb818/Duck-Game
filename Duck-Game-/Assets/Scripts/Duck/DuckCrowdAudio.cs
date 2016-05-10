using UnityEngine;
using System.Collections;

public class DuckCrowdAudio : MonoBehaviour {

	void OnTriggerEnter (Collider p) {
		if (p.CompareTag("Player")) {
			GetComponent<AudioSource>().Play();
		}
	}

	void OnTriggerExit (Collider p) {
		if (p.CompareTag("Player")) {
			GetComponent<AudioSource>().Stop();
		}
	}
}
