using UnityEngine;
using System.Collections;

public class CamTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		CamSwap.camRight = !CamSwap.camRight;
	}

}
