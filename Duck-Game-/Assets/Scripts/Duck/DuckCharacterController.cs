using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	//Vector3 moveDirection = Vector3.zero;

	bool getBread = false;
	bool hasEaten = false;
	Transform posA, posB;

	void Start () {
		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		posA = this.transform;
		posB = this.transform;
	}
	
	void Update () {
		if (getBread && !hasEaten){
            transform.LookAt(posB);
            cc.Move(transform.forward * Time.deltaTime);
		}
	
	}

	void EatBread (GameObject bread){
		posB = bread.transform;
		getBread = true;
		print ("Duck wants bread");
	}

	void OnCollisionEnter (Collision bread){
		if (hasEaten == false){
			if (bread.gameObject.CompareTag("Bread")){
				hasEaten = true;
				print ("hasEaten = true");
				transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
				Destroy(bread.gameObject);
			}
		}
	}
}
