using UnityEngine;
using System.Collections;

public class DuckCall : MonoBehaviour {

	public GameObject[] ducks;
	public bool isCalling;
	AudioSource audio, audioD;
	float dist;
	public float maxDist = 10;
	public float minDist = 1.25f;
	float volD;
	//public GameObject testStudent;
	//public float testDist;

	void Start () {
		isCalling = false;
		ducks = GameObject.FindGameObjectsWithTag("Duck");
		audio = GetComponent<AudioSource>();
	}
	
	void Update () {

		//testDist = Vector3.Distance(testStudent.transform.position, transform.position);
		//print (testDist);
		
		if (Input.GetKeyDown(KeyCode.Mouse0) && isCalling == false){
			StartCoroutine("DCall");
			audio.Play();
		}

	}

	
	IEnumerator DCall () {
		isCalling = true;
		yield return new WaitForSeconds(1);
		foreach (GameObject duck in ducks) {
			audioD = duck.GetComponent<AudioSource>();
			dist = Vector3.Distance(duck.transform.position, transform.position);
			/*
			if (dist <= maxDist && dist > 9f){
				audioD.volume = 0.2f;
			} else if (dist <= 9f && dist > 8f){
				audioD.volume = 0.3f;
			} else if (dist <= 8f && dist > 7f){
				audioD.volume = 0.4f;
			} else if (dist <= 7f && dist > 6f){
				audioD.volume = 0.5f;
			} else if (dist <= 6f && dist > 5f){
				audioD.volume = 0.6f;
			} else if (dist <= 5f && dist > 4f){
				audioD.volume = 0.7f;
			} else if (dist <= 4f && dist > 3f){
				audioD.volume = 0.8f;
			} else if (dist <= 3f && dist > 2f){
				audioD.volume = 0.9f;
			} else if (dist <= 2f && dist > 1f){
				audioD.volume = 1f;
			} else if (dist > maxDist){
				audioD.volume = 0;
			} 
			*/
			if (dist <= maxDist && dist > 7.5f){
				audioD.volume = 0.025f;
			} else if (dist <= 7.5f && dist > 5f){
				audioD.volume = 0.125f;
			} else if (dist <= 5f && dist > 2.5f){
				audioD.volume = 0.5f;
			} else if (dist <= 2.5f && dist > 1f){
				audioD.volume = 1f;
			} else if (dist < 1f){
				audioD.volume = 0;
			} else if (dist > maxDist){
				audioD.volume = 0;
			} 			
			duck.SendMessage("quackback");
		}
		yield return new WaitForSeconds(.75f);
		isCalling = false;
	}	

	void checkDist () {

	}

}
