using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	bool getBread = false;
	bool hasEaten = false;
	GameObject target;
	public float dist;
	public float eatDist;
	public GameObject FOV;
	public float restTime;
	float yPos;

	void Start () {
		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		target = null;
		yPos = transform.position.y;
	}
	
	void Update () {

		transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

		if (target != null){

			/*
			if (target.CompareTag("Bread")){
				print("target = bread"); -- CONFIRMED
			}
			*/

			dist = Vector3.Distance(target.transform.position, transform.position);
			if (getBread && !hasEaten){
            	transform.LookAt(target.transform);
            	//dist = Vector3.Distance(target.transform.position, transform.position);
            	cc.Move(transform.forward * Time.deltaTime);
            	FOV.SetActive(false);
			}
			if (dist <= eatDist){
				StartCoroutine("Resting");				
			}
		}
	
	}

	void EatBread (GameObject bread){
		target = bread.gameObject;
		getBread = true;
		//print ("Duck wants bread"); -- CONFIRMED
	}

	IEnumerator Resting () {
		Destroy (target.gameObject);
		hasEaten = true;
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		target = null;
		FOV.SetActive(false);
		yield return new WaitForSeconds(restTime);
		FOV.SetActive(true);
		hasEaten = false;
	}

}
