using UnityEngine;
using System.Collections;

public class DuckEat : MonoBehaviour {

	bool getBread = false;
	bool hasEaten = false;
	Transform posA, posB;
	public float speed;
    Quaternion smoothRotate;
    Rigidbody rb;


	void Start () {
		posA = this.transform;
		posB = this.transform;
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		if (getBread && !hasEaten){
			/*
			smoothRotate.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0); 
            var newRotation = Quaternion.LookRotation(posB.position - transform.position);
            transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .05f);

            rb.AddForce(transform.forward * speed);
            */
            transform.LookAt(posB);
            rb.AddForce(transform.forward * speed);
		}

		if (transform.position.x == posB.position.x && transform.position.z == posB.position.z && getBread){
			getBread = false;
			hasEaten = true;
		}
	
	}

	void EatBread (GameObject bread){
		posB = bread.transform;
		getBread = true;
		print ("Duck wants bread");
	}

	void OnCollisionEnter (Collision bread){
		if (bread.gameObject.CompareTag("Bread")){
			hasEaten = true;
			transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
			Destroy(bread.gameObject);
		}
	}
}
