using UnityEngine;
using System.Collections;

public class AttractDuck2 : MonoBehaviour {

	//Trigger turned on via AttractDuck.cs

	public GameObject bread;

	void OnTriggerEnter(Collider duck){
		if (duck.CompareTag("Duck")){
			duck.GetComponent<DuckCharacterController>().EatBread(bread.gameObject);
			//duck.SendMessage("EatBread", bread.gameObject);
			//print("duck wants bread"); -- CONFIRMED
		}
	}
}
