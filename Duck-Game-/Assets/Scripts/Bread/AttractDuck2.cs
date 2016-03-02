using UnityEngine;
using System.Collections;

public class AttractDuck2 : MonoBehaviour {

	public GameObject bread;

	void OnTriggerEnter(Collider duck){
		if (duck.CompareTag("Duck")){
			duck.SendMessage("EatBread", bread.gameObject);
			//print("duck wants bread");
		}
	}
}
