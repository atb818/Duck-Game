using UnityEngine;
using System.Collections;

public class NodeMovement : MonoBehaviour {

	Transform t;
	Vector3 oLeft, oRight, oUp, oDown;
	public RaycastHit obstacleHit;
	public LayerMask mask1 = 9;
	GameObject player;

	bool canMoveUp, canMoveDown, canMoveRight, canMoveLeft;

	public static bool isSafe;

	void Start () {
		player = this.gameObject;
		isSafe = true;
	}
	
	void Update () {
		t = this.transform;

		if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canMoveUp){
			t.position = new Vector3 (t.position.x, t.position.y, t.position.z + 1);
		}
		if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && canMoveDown){
			t.position = new Vector3 (t.position.x, t.position.y, t.position.z - 1);
		}
		if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && canMoveLeft){
			t.position = new Vector3 (t.position.x - 1, t.position.y, t.position.z);
		}
		if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && canMoveRight){
			t.position = new Vector3 (t.position.x + 1, t.position.y, t.position.z);
		}

		moveCheck();
	}

	void moveCheck(){

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
