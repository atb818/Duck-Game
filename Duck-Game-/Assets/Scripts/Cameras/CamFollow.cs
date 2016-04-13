using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	Quaternion smoothRotate;
	public GameObject DB;

	void Start () {
	
	}
	
	void Update () {
		smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		var newRotation = Quaternion.LookRotation(DB.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .75f);
	}
}
