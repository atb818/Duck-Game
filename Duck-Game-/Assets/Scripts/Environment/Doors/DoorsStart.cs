using UnityEngine;
using System.Collections;

public class DoorsStart : MonoBehaviour {

	public GameObject hall1, hall2, lroom, gym;

	public static Vector3 h1, h2, lr, g;

	public static bool pastLobby, lobbyDoorsClosed, pastHall, pastGym;

	void Start () {
		h1 = new Vector3 (hall1.transform.rotation.x, hall1.transform.rotation.y, hall1.transform.rotation.z);
		h2 = new Vector3 (hall2.transform.rotation.x, hall2.transform.rotation.y, hall2.transform.rotation.z);
		lr = new Vector3 (lroom.transform.rotation.x, lroom.transform.rotation.y, lroom.transform.rotation.z);
		g = new Vector3 (gym.transform.rotation.x, gym.transform.rotation.y, gym.transform.rotation.z);

		pastLobby = false;
		pastHall = false;
		pastGym = false;


	}
	
	void Update () {
		/*
		if (pastLobby && lobbyDoorsClosed){

			hall1.transform.eulerAngles = new Vector3 (0,hall1.transform.rotation.y + 70x,0);
			hall2.transform.eulerAngles = new Vector3 (0,hall1.transform.rotation.y + 75,0);
		} //else {	
			//hall1.transform.eulerAngles = h1;
			//hall2.transform.eulerAngles = h2;
		//}  

		if (pastHall){
			lroom.transform.eulerAngles = lr;
		} else {
			lroom.transform.eulerAngles = new Vector3 (0,95,0);
		}

		if (pastGym){
			gym.transform.eulerAngles = g;
		} else {
			gym.transform.eulerAngles = new Vector3 (0,-180,0);
		}
		*/
	}
}


