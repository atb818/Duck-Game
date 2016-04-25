using UnityEngine;
using System.Collections;

public class GymSpotOff : MonoBehaviour {

	public GameObject spot;
	public GameObject ducks1;
	public GameObject ducks2;

	void OnTriggerEnter (Collider other){
		if (other.CompareTag("Player")){
			Destroy(spot.gameObject);
			Destroy(ducks1.gameObject);
			ducks2.SetActive(true);
		}
	}
}
