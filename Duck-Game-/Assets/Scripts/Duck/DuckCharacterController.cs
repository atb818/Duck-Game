using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	//Vector3 moveDirection = Vector3.zero;

	bool getBread = false;
	bool hasEaten = false;
	Transform posA, posB;
	GameObject target;
	public float dist;
	public float eatDist;

	void Start () {
		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		posA = this.transform;
		posB = this.transform;
		target = null;
	}
	
	void Update () {
		if (target != null){
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
		}
		}
	
	}

	void EatBread (GameObject bread){
		//posB = bread.transform;
		target = bread;
		getBread = true;
		print ("Duck wants bread");
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
