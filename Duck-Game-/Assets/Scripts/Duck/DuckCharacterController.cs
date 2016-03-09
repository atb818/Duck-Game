using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	float yPos;
	public GameObject DB;

	//SEE BREAD
	GameObject target;
	float breadDist;
	public float eatDist;
	public float restTime;
	bool getBread = false;
	bool isResting = false;

	//SEE PLAYER
	float playerDist;
	public float fovDist;
	bool playerInDist = false;
	bool playerInAngle = false;
	public GameObject FOV;

	void Start () {
		cc = GetComponent<CharacterController>();
		cc.detectCollisions = true;
		target = null;
		yPos = transform.position.y;
	}
	
	void Update () {

		transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

		playerDist = Vector3.Distance(DB.transform.position, transform.position);

		if (isResting == false){
			
			if (playerDist <= fovDist){
				playerInDist = true;
				print ("duck sees player");
			}

			if (playerInDist){
    			transform.LookAt(DB.transform);
    			cc.Move(transform.forward * Time.deltaTime * 2	);
			}
		}

		if (target != null){
			playerInDist = false;
			breadDist = Vector3.Distance(target.transform.position, transform.position);
			if (target.CompareTag("Bread")){
				if (getBread && !isResting){
            		transform.LookAt(target.transform);
            		cc.Move(transform.forward * Time.deltaTime);
            		FOV.SetActive(false);
				}
				if (breadDist <= eatDist){
					StartCoroutine("Resting");				
				}
			}
		}

		//NEW BREAD SCRIPT

	
	}

	public void EatBread (GameObject bread){
		target = bread.gameObject;
		getBread = true;
		//print ("Duck wants bread"); -- CONFIRMED
	}

	IEnumerator Resting () {
		Destroy (target.gameObject);
		isResting = true;
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		target = null;
		FOV.SetActive(false);
		yield return new WaitForSeconds(restTime);
		FOV.SetActive(true);
		isResting = false;
	}

}
