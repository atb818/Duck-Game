using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	float yPos;
	public GameObject DB;

	public float speed;
	Quaternion smoothRotate;
	Quaternion startRot;

	//SEE BREAD
	GameObject target;
	float breadDist;
	public float eatDist;
	public float restTime;
	bool getBread = false;
	bool isResting = false;
	public GameObject[] ducks;

	//SEE PLAYER
	bool chasingPlayer = false;
	//Distance
	float playerDist;
	public float detectDist;
	public float fovDist;
	bool playerInDist = false;
	bool playerDetected = false;
	//Angle
	float playerAngle;
	public float fovAngle;
	bool playerInAngle = false;
	public GameObject FOV;
	bool playerHiding = false;

	//DUCKS RETURN
	Vector3 startPos;
	//Vector3 startRot;

	//DUCK TYPE
	public bool isBasicDuck;
	public bool isPatrolDuck;

	void Start () {
		startPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		startRot.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		target = null;
		yPos = transform.position.y;

		ducks = GameObject.FindGameObjectsWithTag("Duck");
		FOV.SetActive(false);
	}
	
	void Update () {

		transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

		playerDist = Vector3.Distance(DB.transform.position, transform.position);
		Vector3 playerDir = DB.transform.position - transform.position;
		Vector3 duckDir = transform.forward;
		playerAngle = Vector3.Angle(playerDir, duckDir);

		if (isBasicDuck){
			GetPlayer();
		} else if (isPatrolDuck){
			GetPlayer();
			if (!chasingPlayer){
				gameObject.GetComponent<PatrolDuck>().PatrolUpdate();
			} 
		}

		if (target != null){
			playerInDist = false;
			playerInAngle = false;
			playerDetected = false;
			breadDist = Vector3.Distance(target.transform.position, transform.position);
			if (target.CompareTag("Bread")){
				if (getBread && !isResting){
            		//transform.LookAt(target.transform);
            		LookAtTarget(target);
            		cc.Move(transform.forward * Time.deltaTime * speed);
            		//FOV.SetActive(false);
				}
				if (breadDist <= eatDist){
					StartCoroutine("Resting");				
				}
			}
		} else if (target == null && !isResting && !playerInDist){
			//FOV.SetActive(true);
			ReturnToPost();
		}

	}

	void LookAtTarget(GameObject t){
		smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		var newRotation = Quaternion.LookRotation(t.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .05f);
	}

	void ReturnToPost () {
		chasingPlayer = false;

		float returnDist = Vector3.Distance(startPos, transform.position);

		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		transform.LookAt(startPos);

		if (returnDist > 0.5f){
			cc.Move(transform.forward * Time.deltaTime * speed);
		} else {
			//Quaternion.slerp current rot --> startRot
			//transform.eulerAngles = startRot;
			transform.rotation = startRot;
			//smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
			//transform.rotation = Quaternion.Slerp(smoothRotate, startRot, .05f);
		}

		playerInDist = false;
		playerInAngle = false;
		playerDetected = false;
	}

	public void GetPlayer () {
		if (goInside.insideLockerGlobal == false){
			if (isResting == false){
				//Get distance to player
				if (playerDist <= fovDist){
					playerInDist = true;
					//print ("duck sees player");
				}
				if (playerDist <= detectDist){
					playerDetected = true;
				}
				//Get angle to player
				if (playerAngle <= fovAngle){
					playerInAngle = true;
				}
				//Get player
				if ((playerInDist && playerInAngle) || playerDetected){
					//transform.LookAt(DB.transform);
					chasingPlayer = true;
				}
				if (chasingPlayer){
					LookAtTarget(DB);
					cc.Move(transform.forward * Time.deltaTime * speed);
				}
				//Eat player
				if (playerDist <= eatDist){
                    HealthBar.hitPoints -= .005f;
				}
			}
		} else {
			ReturnToPost();
		}
	}

	public void EatBread (GameObject bread){
		target = bread.gameObject;
		getBread = true;
	}

	public void ClearTarget (){
		target = null;
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		//FOV.SetActive(true);
	}

	IEnumerator Resting () {
		Destroy (target.gameObject);
		isResting = true;
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		target = null;
		//FOV.SetActive(false);
		//to other ducks:
		foreach (GameObject d in ducks) {
			d.GetComponent<DuckCharacterController>().ClearTarget();
        }
		yield return new WaitForSeconds(restTime);
		//FOV.SetActive(true);
		isResting = false;
	}

}
