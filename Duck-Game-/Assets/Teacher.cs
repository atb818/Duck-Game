using UnityEngine;
using System.Collections;

public class Teacher : MonoBehaviour {

	float timer;
	public float teachTime;
	public float lookTime;
	public float turnTime;
	public bool looking;
	float teachRot = 180;
	float lookRot = 0;
	Quaternion curRot;
	Quaternion newRot;

	void Start () {
		curRot.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		StartCoroutine("Looking");
	}
	
	void Update () {
		curRot.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(curRot, newRot, .05f);
        /*
		looking = true
		timer >= lookTime & looking = true
		newRot = teachRot
		looking = false
		timer >= teachTime & looking = false
		newRot = lookRot
        */


		/*timer += Time.deltaTime;
        if (timer >= teachTime){
            newRot.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Random.Range(-90, 90), transform.eulerAngles.z);
            timer = 0;
        }	*/

        transform.rotation = Quaternion.Slerp(curRot, newRot, .05f);

	}

	IEnumerator Teaching(){
		//curRot.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		newRot.eulerAngles = new Vector3 (0, teachRot, 0);
		looking = false;
        //transform.rotation = Quaternion.Slerp(curRot, newRot, .05f);
        yield return new WaitForSeconds(teachTime);
        //curRot.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
        newRot.eulerAngles = new Vector3 (0, lookRot, 0);
        //how many seconds to turn back to class?
        yield return new WaitForSeconds(turnTime);
        StartCoroutine("Looking");

	}

	IEnumerator Looking(){
		looking = true;
		yield return new WaitForSeconds(lookTime);
		StartCoroutine("Teaching");
	}
}

/*
        smoothRotate.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0); 
        var newRotation = Quaternion.LookRotation(followMe.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .05f);

        transform.rotation = Quaternion.Slerp(smoothRotate, newRot, .05f);

        */
