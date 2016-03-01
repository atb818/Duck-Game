using UnityEngine;
using System.Collections;

public class AttractDuck : MonoBehaviour {

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
