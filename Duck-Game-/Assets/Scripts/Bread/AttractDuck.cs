using UnityEngine;
using System.Collections;

public class AttractDuck : MonoBehaviour {

	//This script activates the TRIGGER (childed to Bread prefab)
	//On contact with ground, trigger turns on to attract duck

	SphereCollider trig;
	public GameObject trigger;

	void Start () {
		trigger.SetActive(false);
	}

	void OnCollisionEnter (Collision ground){
		if (ground.gameObject.CompareTag("Ground") && trigger != null){
			trigger.SetActive(true);
		}
	}
}
