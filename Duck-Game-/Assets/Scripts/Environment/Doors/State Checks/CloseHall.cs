using UnityEngine;
using System.Collections;

public class CloseHall : MonoBehaviour {

	void OnTriggerEnter(Collider player){
		if (player.CompareTag("Player")){
			DoorsStart.pastHall = true;
		}
	}
}
