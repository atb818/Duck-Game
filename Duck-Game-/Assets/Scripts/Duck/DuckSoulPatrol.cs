using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DuckSoulPatrol : MonoBehaviour {

	CharacterController cc;
	float yPos;

	float speed;
	public float normalSpeed;
	Quaternion smoothRotate;
	//Quaternion startRot;

	public GameObject[] Nodes;

	public GameObject DemonDuck;
	public GameObject DB;

	bool lastNode = false;

	//Hall Doors
	//public GameObject hall1, hall2, hallCol;

	//PATROL DUCK
	int currentNode;
	bool returning = false;

	void Start () {
		currentNode = 0;

		//start = (GameObject) Instantiate (StartNode, transform.position, Quaternion.identity);

		transform.position = new Vector3 (DemonDuck.transform.position.x, 1.83f, DemonDuck.transform.position.z);

		//startPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		//startRot.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		yPos = transform.position.y + 0.1f;

		/*
		if (DoorCloseMessage.lobbyClosed == false) {
			hall1.GetComponent<DoorClose>().ClosingTime();
			hall2.GetComponent<DoorClose>().ClosingTime();
			hallCol.SetActive(true);

			print("closing hall doors");
		}
		*/

	}
	
	void Update () {

		speed = normalSpeed;

		if (!lastNode){
			Patrolling();
		} else {
			Destroy(gameObject);
		}

		//print (currentNode);

		transform.position = new Vector3 (transform.position.x, 1.83f, transform.position.z);

	}

	void LookAtTarget(GameObject t){
		smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		var newRotation = Quaternion.LookRotation(t.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .85f);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

	void Patrolling () {
		GameObject target = Nodes[currentNode];

		float nodeDist = Vector3.Distance(target.transform.position, transform.position);

		if (nodeDist <= 1f) {
			if (currentNode != Nodes.Length-1){
				currentNode++;
				print ("at node");
			} else {
				//this.SetActive(false);
				//cc.detectCollisions = false;
				//DB.SetActive(false);
				//DB.SetActive(true);
				//Invoke ("DestroyMe", 5f);
				//Destroy(gameObject);
				print ("reached last note");
				lastNode = true;

			}
		}

		/*
		//LookAtTarget(target);
		smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		var newRotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .85f);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		*/

		transform.LookAt(target.transform);

		cc.Move(transform.forward * Time.deltaTime * speed);

	}

	/*
	void DestroyMe(){
		Destroy(gameObject);
	}
	*/

	void OnDisable () {
		DB.SetActive(false);
		DB.SetActive(true);
	}

}
