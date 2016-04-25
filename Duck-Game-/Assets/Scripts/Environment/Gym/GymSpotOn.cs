using UnityEngine;
using System.Collections;

public class GymSpotOn : MonoBehaviour {

	public GameObject spot;

	void Start () {
		spot.SetActive(false);
	}
	
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag("Player")){
			spot.SetActive(true);
		}
	}
}
