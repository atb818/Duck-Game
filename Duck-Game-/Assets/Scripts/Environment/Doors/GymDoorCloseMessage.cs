using UnityEngine;
using System.Collections;

public class GymDoorCloseMessage : MonoBehaviour {

	public GameObject door;

	void Start () {
		//doorCollider.SetActive(false);
	}

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Player"){
			door.GetComponent<GymDoorClose>().ClosingTime();
			//doorCollider.SetActive(true);
        }
    }
}
