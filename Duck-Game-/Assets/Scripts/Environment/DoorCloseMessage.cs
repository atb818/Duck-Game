using UnityEngine;
using System.Collections;

public class DoorCloseMessage : MonoBehaviour {

	public GameObject doorL, doorR, doorCollider;

	void Start () {
		doorCollider.SetActive(false);
	}

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Player"){
			doorL.GetComponent<DoorClose>().ClosingTime();
			doorR.GetComponent<DoorClose>().ClosingTime();
			doorCollider.SetActive(true);
        }
    }
}
