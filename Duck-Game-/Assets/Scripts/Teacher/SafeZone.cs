using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		//print(NodeMovement.isSafe);
	}

	void OnTriggerEnter(Collider player){
		if (player.CompareTag("Player")){
			NodeMovement.isSafe = true;
		}
	}

	void OnTriggerExit(Collider player){
		if (player.CompareTag("Player")){
			NodeMovement.isSafe = false;
		}
	}

}
