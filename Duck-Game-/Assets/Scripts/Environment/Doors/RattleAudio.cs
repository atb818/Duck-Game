using UnityEngine;
using System.Collections;

public class RattleAudio : MonoBehaviour {

	void OnCollisionEnter (Collision player) {
		if (player.gameObject.CompareTag("Player")) {
			GetComponent<AudioSource>().Play();
		}
	}
}
