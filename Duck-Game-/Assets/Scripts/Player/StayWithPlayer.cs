using UnityEngine;
using System.Collections;

public class StayWithPlayer : MonoBehaviour {

	public GameObject DB;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (DB.transform.position.x, transform.position.y, DB.transform.position.z);
	}
}
