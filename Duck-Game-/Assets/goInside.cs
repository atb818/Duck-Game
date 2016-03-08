using UnityEngine;
using System.Collections;

public class goInside : MonoBehaviour {

    bool insideLocker;
    public lockerDoor script;

	void Update () {
	
        if(insideLocker == true )
        {
            if (Input.GetKeyDown(KeyCode.E)){
                script.changeDoor();
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
