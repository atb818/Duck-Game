using UnityEngine;
using System.Collections;

public class goInside : MonoBehaviour {

    bool insideLocker;
    public lockerDoor script;
    public GameObject player;

	void Update () {
	
        if(insideLocker == true )
        {
            if (Input.GetKeyDown(KeyCode.E)){
                script.changeDoor();

                player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, this.transform.position.z);

            }
        }

	}

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            insideLocker = true;

        }
    }
}
