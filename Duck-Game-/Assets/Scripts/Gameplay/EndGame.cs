using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider player) {
		if (player.CompareTag("Player")){
			print ("DuckBoy escaped!");
			//fade to white
		}
	}
}
