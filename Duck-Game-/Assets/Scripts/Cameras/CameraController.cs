using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject CurrentCam;
	GameObject PreviousCam;
	GameObject[] cameras;

	void Start () {
		//Camera.SetActive(false);
		cameras = GameObject.FindGameObjectsWithTag("MainCamera");
	}

	void OnDrawGizmos (){
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawWireCube(transform.position, transform.localScale);
		Gizmos.color = new Color(0,1,0,0.5f);
		Gizmos.DrawLine(transform.position, CurrentCam.transform.position);
	}
	
	void OnTriggerEnter (Collider player) {
		if (player.CompareTag("Player")){
			GetComponent<AudioSource>().Play();
			foreach (GameObject cam in cameras) {
				cam.SetActive(false);
        	}
			CurrentCam.SetActive(true);
			//player.gameObject.GetComponent<PreviousCam>().SetCurrentCam(CurrentCam);
		}
	}

	/*
	void OnTriggerExit (Collider player) {
		if (player.CompareTag("Player")){
			player.gameObject.GetComponent<PreviousCam>().SetPreviousCam(CurrentCam);
			//CurrentCam.SetActive(false);
		}
	}
	*/

}
