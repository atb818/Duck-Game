using UnityEngine;
using System.Collections;

public class DoorClose : MonoBehaviour {

    Quaternion newRotation;
    Vector3 startRot;

    bool closeDoor;
    bool doorOpen;
    public bool isLeftDoor;
    public float openAngle;

    void Start() {
        startRot = transform.eulerAngles;
        closeDoor = false;
        doorOpen = true;

        startRot = new Vector3 (0,0,0);
    }

	void Update () {

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);

        if (closeDoor){
        	if (isLeftDoor){
        		newRotation = Quaternion.AngleAxis(startRot.y - openAngle, Vector3.up);
        	} else if (isLeftDoor == false){
        		newRotation = Quaternion.AngleAxis(startRot.y + openAngle, Vector3.up);
        	}
        }        
    }

    public void ClosingTime(){
    	if (doorOpen){
    		closeDoor = true;
    		doorOpen = false;
		}
    }

}
