using UnityEngine;
using System.Collections;

public class Victory1 : MonoBehaviour {

	public GameObject closedDoor;

	void Start () {
		closedDoor.SetActive(false);
	}

	void OnTriggerEnter (Collider player){
		if (player.CompareTag("Player")){
			print ("YOU WIN!");
			closedDoor.SetActive(true);
		}
	}
}
