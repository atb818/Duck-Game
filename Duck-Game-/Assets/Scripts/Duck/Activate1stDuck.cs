using UnityEngine;
using System.Collections;

public class Activate1stDuck : MonoBehaviour {

	public GameObject duck1;

	void Start () {
		duck1.SetActive(false);
	}
	
	void OnTriggerEnter (Collider db) {
		if (db.CompareTag("Player")){
			duck1.SetActive(true);
		}
	}
}
