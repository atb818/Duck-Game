using UnityEngine;
using System.Collections;

public class CloseLobby : MonoBehaviour {

	public GameObject lobbyCollider;

	void OnTriggerEnter(Collider player){
		if (player.CompareTag("Player")){
			DoorsStart.pastLobby = true;
			lobbyCollider.SetActive(true);
			
		}
	}
}
