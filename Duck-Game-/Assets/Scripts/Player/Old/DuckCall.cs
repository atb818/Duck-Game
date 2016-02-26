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

	public GameObject hear1, hear2, hear3, hear4;
	//public GameObject testStudent;
	//public float testDist;

	void Start () {
		isCalling = false;
		ducks = GameObject.FindGameObjectsWithTag("Duck");
		audio = GetComponent<AudioSource>();

		hear1.SetActive(false);
		hear2.SetActive(false);
		hear3.SetActive(false);
		hear4.SetActive(false);
	}
	
	void Update () {

		//testDist = Vector3.Distance(testStudent.transform.position, transform.position);
		//print (testDist);
		
		if (Input.GetKeyDown(KeyCode.Mouse1) && isCalling == false){
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

			if (dist <= maxDist && dist > 7.5f){
				audioD.volume = 0.025f;
				hear1.SetActive(true);
			} else if (dist <= 7.5f && dist > 5f){
				audioD.volume = 0.125f;
				hear2.SetActive(true);
			} else if (dist <= 5f && dist > 2.5f){
				audioD.volume = 0.5f;
				hear3.SetActive(true);
			} else if (dist <= 2.5f && dist > 1f){
				audioD.volume = 1f;
				hear4.SetActive(true);
			} else if (dist < 1f){
				audioD.volume = 0;
			} else if (dist > maxDist){
				audioD.volume = 0;
			} 			
			duck.SendMessage("quackback");

		}
		yield return new WaitForSeconds(.25f);
		hear1.SetActive(false);
		hear2.SetActive(false);
		hear3.SetActive(false);
		hear4.SetActive(false);
		yield return new WaitForSeconds(.5f);
		isCalling = false;

	}	

	void checkDist () {

	}

}
