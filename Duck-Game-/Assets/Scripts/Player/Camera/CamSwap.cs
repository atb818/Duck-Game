using UnityEngine;
using System.Collections;

public class CamSwap : MonoBehaviour {

	public GameObject camR, camL;
	public static bool camRight = true;

	void Start () {
		camR.SetActive(true);
		camL.SetActive(false);
	}
	
	void Update () {
		if (camRight){
			camR.SetActive(true);
			camL.SetActive(false);
		} else {
			camR.SetActive(false);
			camL.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.C)){
			Swap();
		}
	
	}

	void Swap () {
		camRight = !camRight;
	}
}
