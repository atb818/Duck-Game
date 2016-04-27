using UnityEngine;
using System.Collections;

public class InBush : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider player){
		if (player.CompareTag("Player")){
			goInside.insideLockerGlobal = true;
		}
	}

	void OnTriggerExit (Collider player){
		if (player.CompareTag("Player")){
			goInside.insideLockerGlobal = false;
		}
	}
}
