using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	float yPos;
	public GameObject DB;

	public float speed;

	//SEE BREAD
	GameObject target;
	float breadDist;
	public float eatDist;
	public float restTime;
	bool getBread = false;
	bool isResting = false;
	public GameObject[] ducks;

	//SEE PLAYER
	//Distance
	float playerDist;
	public float fovDist;
	bool playerInDist = false;
	//Angle
	float playerAngle;
	public float fovAngle;
	bool playerInAngle = false;
	public GameObject FOV;

	void Start () {
		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		target = null;
		yPos = transform.position.y;

		ducks = GameObject.FindGameObjectsWithTag("Duck");
	}
	
	void Update () {

		transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

		playerDist = Vector3.Distance(DB.transform.position, transform.position);
		Vector3 playerDir = DB.transform.position - transform.position;
		Vector3 duckDir = transform.forward;
		playerAngle = Vector3.Angle(playerDir, duckDir);

		GetPlayer();

		if (target != null){
			playerInDist = false;
			playerInAngle = false;
			breadDist = Vector3.Distance(target.transform.position, transform.position);
			if (target.CompareTag("Bread")){
				if (getBread && !isResting){
            		transform.LookAt(target.transform);
            		cc.Move(transform.forward * Time.deltaTime * speed);
            		FOV.SetActive(false);
				}
				if (breadDist <= eatDist){
					StartCoroutine("Resting");				
				}
			}
		} else if (target == null && !isResting){
			FOV.SetActive(true);
			transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		}

		//NEW BREAD SCRIPT

	
	}

	void GetPlayer () {
		if (isResting == false){
			//Get distance to player
			if (playerDist <= fovDist){
				playerInDist = true;
				//print ("duck sees player");
			}
			//Get angle to player
			if (playerAngle <= fovAngle){
				playerInAngle = true;
			}

			if (playerInDist && playerInAngle){
				transform.LookAt(DB.transform);
				cc.Move(transform.forward * Time.deltaTime * speed);
			}
		}
	}

	public void EatBread (GameObject bread){
		target = bread.gameObject;
		getBread = true;
		//print ("Duck wants bread"); -- CONFIRMED
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
		FOV.SetActive(false);
		//to other ducks:
		foreach (GameObject d in ducks) {
			d.GetComponent<DuckCharacterController>().ClearTarget();
        }
		yield return new WaitForSeconds(restTime);
		FOV.SetActive(true);
		isResting = false;
	}

}
