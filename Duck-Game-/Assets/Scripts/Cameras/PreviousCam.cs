using UnityEngine;
using System.Collections;

public class PreviousCam : MonoBehaviour {

	GameObject currCam;
	GameObject prevCam;
	GameObject[] cameras;


	void Start () {
		prevCam = null;
		cameras = GameObject.FindGameObjectsWithTag("MainCamera");

	}
	
	void Update () {
		if (prevCam != null){
			if (Input.GetKeyDown(KeyCode.Q)){
				prevCam.SetActive(true);
				currCam.SetActive(false);
			}
			if (Input.GetKeyUp(KeyCode.Q)){
				prevCam.SetActive(false);
				foreach (GameObject cam in cameras) {
					cam.SetActive(false);
        		}
				currCam.SetActive(true);
			}
		}
	}

	public void SetCurrentCam (GameObject cam){
		//on trigger enter CamController.cs
		currCam = cam;
		if (prevCam != null){
			prevCam.SetActive(false);
		}
	}

	public void SetPreviousCam (GameObject cam){
		//on trigger exit CamController.cs
		prevCam = cam;
	}
}
