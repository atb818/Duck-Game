using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DuckSoulPatrol : MonoBehaviour {

	CharacterController cc;
	float yPos;

	float speed;
	public float normalSpeed;
	Quaternion smoothRotate;
	Quaternion startRot;

	public GameObject[] Nodes;

	public GameObject DemonDuck;
	public GameObject DB;

	//DUCKS RETURN
	Vector3 startPos;
	//GameObject start;

	//PATROL DUCK
	int currentNode;
	bool returning = false;

	void Start () {
		currentNode = 0;

		//start = (GameObject) Instantiate (StartNode, transform.position, Quaternion.identity);

		transform.position = new Vector3 (DemonDuck.transform.position.x, 1.83f, DemonDuck.transform.position.z);

		startPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		startRot.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		yPos = transform.position.y + 0.1f;

	}
	
	void Update () {
		speed = normalSpeed;

		Patrolling();

		print (currentNode);

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
			if (currentNode < Nodes.Length){
				currentNode++;
			}
			if (currentNode == Nodes.Length){
				Destroy(gameObject);
				DB.SetActive(false);
				DB.SetActive(true);
			}
		}

		//LookAtTarget(target);
		smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		var newRotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .85f);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		cc.Move(transform.forward * Time.deltaTime * speed);

	}

}
