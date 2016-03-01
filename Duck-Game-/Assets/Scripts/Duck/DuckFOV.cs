using UnityEngine;
using System.Collections;

public class DuckFOV : MonoBehaviour {

	void OnTriggerEnter(Collider player){
		if (player.CompareTag("Player")){
			print("SPOTTED");
		}
	}
	
}
