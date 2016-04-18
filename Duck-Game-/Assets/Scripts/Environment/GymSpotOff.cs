using UnityEngine;
using System.Collections;

public class GymSpotOff : MonoBehaviour {

	public GameObject spot;

	void OnTriggerEnter (Collider other){
		if (other.CompareTag("Player")){
			Destroy(spot.gameObject);
		}
	}
}
