using UnityEngine;
using System.Collections;

public class goInside : MonoBehaviour {

    public static bool insideLockerGlobal = false;
    bool insideLocker = false;
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
            if (!insideLocker)
            {
                insideLocker = true;
                insideLockerGlobal = true;
            } else if (insideLocker)
            {
                insideLocker = false;
                insideLockerGlobal = false;
            }
        }
 
    }
}
