using UnityEngine;
using System.Collections;

public class TeacherCheck : MonoBehaviour {

	public float leftRot;
	public float rightRot;
	public bool isSafe;

	void Start () {
	
	}
	
	void Update () {
	
		if (transform.eulerAngles.y >= rightRot && transform.eulerAngles.y <= leftRot){
			isSafe = false;
		} else {
			isSafe = true;
		}

		//print(transform.eulerAngles.y);
	}

	void teacher(){
		if (isSafe){
			print("SAFE");
		} else if (isSafe == false){
			print("CAUGHT");
		}
	}

}
