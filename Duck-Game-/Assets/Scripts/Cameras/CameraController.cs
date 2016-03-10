using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject Camera;
	public GameObject[] cameras;

	void Start () {
		//Camera.SetActive(false);
		cameras = GameObject.FindGameObjectsWithTag("MainCamera");
	}
	
	void OnTriggerEnter (Collider player) {
		if (player.CompareTag("Player")){
			foreach (GameObject cam in cameras) {
				cam.SetActive(false);
        	}
			Camera.SetActive(true);
		}
	}

}
