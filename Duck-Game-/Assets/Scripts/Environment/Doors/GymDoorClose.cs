using UnityEngine;
using System.Collections;

public class GymDoorClose : MonoBehaviour {

	Quaternion newRotation;
    Vector3 startRot;

    bool closeDoor;
    bool doorOpen;
    public float openAngle;

    void Start() {
        startRot = transform.eulerAngles;
        closeDoor = false;
        doorOpen = true;
    }

	void Update () {

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.5f);

        if (closeDoor){
        	newRotation = Quaternion.AngleAxis(startRot.y - openAngle, Vector3.up);
        }      
    }

    public void ClosingTime(){
    	closeDoor = true;
    	doorOpen = false;
    	print("door closing");
    }
}
