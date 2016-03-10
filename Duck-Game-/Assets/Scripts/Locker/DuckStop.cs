using UnityEngine;
using System.Collections;

public class DuckStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider duck){
		if (duck.CompareTag("Duck")){
			duck.GetComponent<DuckCharacterController>().SearchForPlayer();
		}
	}
}
