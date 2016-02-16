using UnityEngine;
using System.Collections;

public class NodeMovement : MonoBehaviour {

	Transform t;
	Vector3 oLeft, oRight, oUp, oDown;
	public RaycastHit obstacleHit;
	public LayerMask mask1 = 9;
	GameObject player;

	bool canMoveUp, canMoveDown, canMoveRight, canMoveLeft;

	void Start () {
		player = this.gameObject;
	}
	
	void Update () {
		t = this.transform;

		/*
		oUp.position = new Vector3 (t.position.x, t.position.y, t.position.z + 1);
		oDown.position = new Vector3 (t.position.x, t.position.y, t.position.z - 1);
		oLeft.position = new Vector3 (t.position.x - 1, t.position.y, t.position.z);
		oRight.position = new Vector3 (t.position.x + 1, t.position.y, t.position.z);

		Vector3 oUp = t.forward;
		Vector3 oDown = -t.forward;
		Vector3 oLeft = -t.right;
		Vector3 oRight = t.right;
		*/

		if (Input.GetKeyDown(KeyCode.UpArrow) && canMoveUp){
			t.position = new Vector3 (t.position.x, t.position.y, t.position.z + 1);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && canMoveDown){
			t.position = new Vector3 (t.position.x, t.position.y, t.position.z - 1);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && canMoveLeft){
			t.position = new Vector3 (t.position.x - 1, t.position.y, t.position.z);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && canMoveRight){
			t.position = new Vector3 (t.position.x + 1, t.position.y, t.position.z);
		}


		moveCheck();
	}

	void moveCheck(){
		//Ray rayUp = gameObject.transform.position (t.forward);
		//Ray rayDown = gameObject.transform.position(-t.forward);
		//Ray rayRight = gameObject.transform.position(t.right);
		//Ray rayLeft = gameObject.transform.position(-t.right);
		//RaycastHit rayHit = new RaycastHit();

		//Debug.DrawRay(rayUp.origin, rayUp.direction * 100f, Color.yellow);

		Vector3 rayUp = t.TransformDirection(new Vector3 (0, 0, 1));
		Vector3 rayDown = t.TransformDirection(new Vector3 (0, 0, -1));
		Vector3 rayRight = t.TransformDirection(new Vector3 (1, 0, 0));
		Vector3 rayLeft = t.TransformDirection(new Vector3 (-1, 0, 0));
		Debug.DrawRay(t.position, rayUp * 100f, Color.yellow);
		RaycastHit rayHit = new RaycastHit();

		if (Physics.Raycast(t.position, rayUp, out rayHit, 1f, mask1.value)){
			canMoveUp = false;
		} else {
			canMoveUp = true;
		}
		if (Physics.Raycast(t.position, rayDown, out rayHit, 1f, mask1.value)){
			canMoveDown = false;
		} else {
			canMoveDown = true;
		}
		if (Physics.Raycast(t.position, rayRight, out rayHit, 1f, mask1.value)){
			canMoveRight = false;
		} else {
			canMoveRight = true;
		}
		if (Physics.Raycast(t.position, rayLeft, out rayHit, 1f, mask1.value)){
			canMoveLeft = false;
		} else {
			canMoveLeft = true;
		}

	}
}
