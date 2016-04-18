using UnityEngine;
using System.Collections;

public class GymSpot : MonoBehaviour {

	public GameObject DB;

	void Start () {
		//this.gameObject.SetActive(false);
	}
	
	void Update () {
		transform.position = new Vector3 (DB.transform.position.x, transform.position.y, DB.transform.position.z);
	}
}
