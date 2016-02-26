using UnityEngine;
using System.Collections;

public class DuckFOV : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collision player){
		if (player.CompareTag("Player")){
			//GET IT
		}
	}
}
