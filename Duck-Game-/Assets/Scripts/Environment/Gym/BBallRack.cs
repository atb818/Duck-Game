using UnityEngine;
using System.Collections;

public class BBallRack : MonoBehaviour {

	public GameObject[] parts;

	void OnTriggerEnter (Collider other){
		if (other.CompareTag("Player") || other.CompareTag("Bread") || other.CompareTag("Duck")){
			foreach (GameObject part in parts) {
				part.GetComponent<Rigidbody>().isKinematic = false;
        	}
		}
	}
}
