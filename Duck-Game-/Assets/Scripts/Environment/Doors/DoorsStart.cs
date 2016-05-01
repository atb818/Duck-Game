using UnityEngine;
using System.Collections;

public class DoorsStart : MonoBehaviour {

	public GameObject hall1, hall2, lroom, gym;

	// Use this for initialization
	void Start () {
	
		//hall1.transform.eulerAngles = new Vector3 (0,0,0);
		//hall2.transform.eulerAngles = new Vector3 (0,0,0);
		lroom.transform.eulerAngles = new Vector3 (0,95,0);
		gym.transform.eulerAngles = new Vector3 (0,-180,0);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
