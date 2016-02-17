using UnityEngine;
using System.Collections;

public class TeacherCheck : MonoBehaviour {

	public float leftRot;
	public float rightRot;
	public static bool hidden;

	void Start () {
		hidden = true;
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Mouse0)){
			NodeMovement.isSafe = false;
		}

		if (Input.GetKeyUp(KeyCode.Mouse0)){
			NodeMovement.isSafe = true;
		}

		if (Teacher.looking){
			if (NodeMovement.isSafe){
				print("Hidden from teacher!");
			} else if (NodeMovement.isSafe == false){
				print("Teacher caught you!");
			}	
		} else if (Teacher.looking == false){
			print ("Teacher isn't looking...");
		}
	
		/*
		if (NodeMovement.isSafe){
			hidden = true;
		} else {
			hidden = false;
		}
		*/

		//teacher();
	}

	void teacher(){
		if (Teacher.looking){
			if (hidden){
				print("SAFE");
			} else if (hidden == false){
				print("CAUGHT");
			}
		}	
	}

}
