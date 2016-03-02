using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	bool getBread = false;
	bool hasEaten = false;
	//Transform posA, posB;
	GameObject target;
	public float dist;
	public float eatDist;
	public GameObject FOV;

	void Start () {
		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		target = null;
		//posA = this.transform;
		//posB = this.transform;
	}
	
	void Update () {

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
			}
			if (dist <= eatDist){
				hasEaten = true;
				transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
				Destroy (target.gameObject);
				target = null;
				print ("duck has eaten");
				//Below is just for testing -- MUST be changed when reticle aiming is implemented!!!!
				FOV.SetActive(false);
			}
		}
	
	}

	void EatBread (GameObject bread){
		target = bread.gameObject;
		getBread = true;
		//print ("Duck wants bread"); -- CONFIRMED
	}

	/*
	void OnTriggerEnter (Collider bread){
		if (hasEaten == false){
			if (bread.gameObject.CompareTag("Bread")){
				hasEaten = true;
				print ("hasEaten = true");
				transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
				Destroy(bread.gameObject);
			}
		}
	}
	*/
}
