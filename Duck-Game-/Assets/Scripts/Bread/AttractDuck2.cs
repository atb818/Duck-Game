using UnityEngine;
using System.Collections;

public class AttractDuck2 : MonoBehaviour {

	void OnTriggerEnter(Collider duck){
		if (duck.CompareTag("Duck")){
			duck.SendMessage("EatBread", this.gameObject);
			print("duck wants bread");
		}
	}
}
