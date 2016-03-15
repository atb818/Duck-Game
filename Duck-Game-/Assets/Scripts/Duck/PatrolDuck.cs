using UnityEngine;
using System.Collections;

public class PatrolDuck : MonoBehaviour {

	public Transform[] Nodes;
	Transform prevNode;
	Transform nextNode;
	int currentNode;
	int numberOfNodes;
	float nodeDist;
	NavMeshAgent agent;
	bool returning = false;
	float startTime;
	public float speed;
	float currentTime;
	float lerpTime;

	void Start () {
		//agent = GetComponent<NavMeshAgent>();
		//agent.autoBreaking = false;

		//NextNode();

		prevNode = gameObject.transform;
		currentNode = 1;
		numberOfNodes = Nodes.Length;

		startTime = Time.time;
	}

	public void PatrolUpdate () {
		print(currentNode);
		nextNode = Nodes[currentNode];
		transform.LookAt(nextNode);
		nodeDist = Vector3.Distance(nextNode.position, transform.position);
		if (nodeDist <= .5f) {
			currentTime = 0; //TEST
			prevNode = gameObject.transform;
			if (!returning){
				print ("not returning");
				if (currentNode >= Nodes.Length-1){
					currentNode--;
					returning = true;
				} else {
					currentNode++;
				}
			} else {
				print("returning");
				if (currentNode <= 0 && returning){
					currentNode++;
					returning = false;
				} else {
					currentNode--;
				}
			}
		}

		currentTime += Time.deltaTime;
		lerpTime = nodeDist * 5;
		if (currentTime > lerpTime){
			currentTime = lerpTime;
		}
		float journey = currentTime / lerpTime;
		//float distCovered = (Time.time - startTime * speed);
		//float journeyLength = Vector3.Distance(prevNode.position, nextNode.position);
		//float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(prevNode.position, nextNode.position, journey);

	}

}
