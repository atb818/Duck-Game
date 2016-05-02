using UnityEngine;
using System.Collections;

public class CloseLobby : MonoBehaviour {

	void OnTriggerEnter(Collider player){
		if (player.CompareTag("Player")){
			DoorsStart.pastLobby = true;
		}
	}
}
