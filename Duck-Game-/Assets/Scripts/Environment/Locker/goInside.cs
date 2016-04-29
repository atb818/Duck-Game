using UnityEngine;
using System.Collections;

public class goInside : MonoBehaviour {

    public static bool insideLockerGlobal;
    public static bool canShoot = true;
    bool insideLocker = false;
    public lockerDoor script;
    GameObject player;
    //public GameObject target;

    //awkward directional debug booleans -___-
    public bool movePosX;
    public bool moveNegX;
    public bool moveZ;


    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       //hinge = GameObject.Find("DoorHingeJoint");

        
    
    }

	void Update () {
        
        

        if (insideLocker == true ) {
            //if (Input.GetKeyDown(KeyCode.E)){
            if (Input.GetButtonDown("Interact")){
                script.changeDoor();
                //hinge.GetComponent<lockerDoor>().changeDoor();

                player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, this.transform.position.z);

                player.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                
                if (insideLockerGlobal){
                    insideLockerGlobal = false;
                    player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;
                    player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
                    if (moveZ){
                    	player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + .9f);
                	} else if (movePosX){
                    	player.transform.position = new Vector3(player.transform.position.x + .9f, player.transform.position.y, player.transform.position.z);
                	} else if (moveNegX){
                    	player.transform.position = new Vector3(player.transform.position.x - .9f, player.transform.position.y, player.transform.position.z);
                	}
                    player.transform.rotation = Quaternion.Lerp(player.transform.rotation, this.transform.rotation, 1);

                } else {
                    insideLockerGlobal = true;
                   
                }
            }
        }

	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            
                insideLocker = true;
            // insideLockerGlobal = true;
            canShoot = false;
        }
 
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {

            insideLocker = false;
            // insideLockerGlobal = false;
            canShoot = true;
            

        }

    }

    

}
