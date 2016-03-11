using UnityEngine;
using System.Collections;

public class goInside : MonoBehaviour {

    public static bool insideLockerGlobal = false;
    bool insideLocker = false;
    //GameObject hinge;

    public lockerDoor script;
    GameObject player;


    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       //hinge = GameObject.Find("DoorHingeJoint");

        
    
    }

	void Update () {

        //print(insideLocker);
        //print(insideLockerGlobal);
	
        if (insideLocker == true ) {
            if (Input.GetKeyDown(KeyCode.E)){
                script.changeDoor();
                //hinge.GetComponent<lockerDoor>().changeDoor();

                player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, this.transform.position.z);
                if (insideLockerGlobal){
                    insideLockerGlobal = false;
                } else {
                    insideLockerGlobal = true;
                }
            }
        }

	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            
                insideLocker = true;
                //insideLockerGlobal = true;
        }
 
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {

            insideLocker = false;
            //insideLockerGlobal = false;
        }

    }

}
