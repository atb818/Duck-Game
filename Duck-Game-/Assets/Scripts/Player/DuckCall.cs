using UnityEngine;
using System.Collections;

public class DuckCall : MonoBehaviour {

	public GameObject[] ducks;
	public bool isCalling;
	AudioSource audio;

	void Start () {
		isCalling = false;
		ducks = GameObject.FindGameObjectsWithTag("Duck");
		audio = GetComponent<AudioSource>();
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Mouse0) && isCalling == false){
			StartCoroutine("DCall");
			audio.Play();
		}

	}

	
	IEnumerator DCall () {
		isCalling = true;
		yield return new WaitForSeconds(2);
		foreach (GameObject duck in ducks) {
			duck.SendMessage("quackback");
		}
		yield return new WaitForSeconds(1);
		isCalling = false;
	}
	

}
