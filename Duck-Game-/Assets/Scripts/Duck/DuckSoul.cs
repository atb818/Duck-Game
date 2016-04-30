using UnityEngine;
using System.Collections;

public class DuckSoul : MonoBehaviour {

	GameObject target;
	int currentNode;
	public GameObject[] Nodes;
	//public GameObject StartNode;
	Quaternion smoothRotate;
	public float speed;
	public GameObject dd;



	void Start () {
		currentNode = 0;
	}

	void OnEnable(){
		//transform.position = new Vector3 (dd.transform.position.x, transform.position.y, dd.transform.position.z);
	}
	
	void Update () {
		target = Nodes[currentNode];

		float nodeDist = Vector3.Distance(target.transform.position, transform.position);

		if (nodeDist <= .5f) {
			if (currentNode < Nodes.Length){
				currentNode++;
			}
			if (currentNode == Nodes.Length){
				Destroy(gameObject);
			}
		}

		LookAtTarget(target);
		transform.position += Vector3.forward * Time.deltaTime * speed;

		print (currentNode);
	}

	public void LookAtTarget(GameObject t){
		smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		var newRotation = Quaternion.LookRotation(t.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .85f);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

}
