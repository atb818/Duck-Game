using UnityEngine;
using System.Collections;

public class DoorCloseMessage : MonoBehaviour {

	public GameObject doorL, doorR, doorCollider;

	public static bool lobbyClosed;

	void Start () {
		doorCollider.SetActive(false);
		lobbyClosed = false;
	}

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Player"){
        	lobbyClosed = true;
			doorL.GetComponent<DoorClose>().ClosingTime();
			doorR.GetComponent<DoorClose>().ClosingTime();
			doorCollider.SetActive(true);
			DoorsStart.lobbyDoorsClosed = true;
        }
    }
}
