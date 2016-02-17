using UnityEngine;
using System.Collections;

public class Teacher : MonoBehaviour {

	public GameObject duckboy;

	float timer;
	public float teachTime;
	public float lookTime;
	public float turnTime;
	public static bool looking;
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
	}

	IEnumerator Teaching(){
		newRot.eulerAngles = new Vector3 (0, teachRot, 0);
		looking = false;
        yield return new WaitForSeconds(teachTime);
        newRot.eulerAngles = new Vector3 (0, lookRot, 0);
        yield return new WaitForSeconds(turnTime);
        StartCoroutine("Looking");
	}

	IEnumerator Looking(){
		looking = true;
		yield return new WaitForSeconds(lookTime);
		StartCoroutine("Teaching");
	}
}
