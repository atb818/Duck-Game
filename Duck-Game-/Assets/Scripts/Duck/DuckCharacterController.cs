using UnityEngine;
using System.Collections;

public class DuckCharacterController : MonoBehaviour {

	CharacterController cc;
	float yPos;
	public GameObject DB;

	//See Bread
	GameObject target;
	float breadDist;
	public float eatDist;
	public float restTime;
	bool getBread = false;
	bool hasEaten = false;

	//See Player
	float playerDist;
	public float fovDist;
	bool getPlayer = false;
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

		if (playerDist <= fovDist){
			getPlayer = true;
			print ("duck sees player");
    		//transform.LookAt(DB.transform);
    		//cc.Move(transform.forward * Time.deltaTime);
		}

		if (getPlayer){
    		transform.LookAt(DB.transform);
    		cc.Move(transform.forward * Time.deltaTime * 2);
		}

		if (target != null){
			getPlayer = false;
			breadDist = Vector3.Distance(target.transform.position, transform.position);
			if (target.CompareTag("Bread")){
				if (getBread && !hasEaten){
            		transform.LookAt(target.transform);
            		cc.Move(transform.forward * Time.deltaTime);
            		FOV.SetActive(false);
				}
				if (breadDist <= eatDist){
					StartCoroutine("Resting");				
				}
			}
		}
	
	}

	void EatBread (GameObject bread){
		target = bread.gameObject;
		getBread = true;
		//print ("Duck wants bread"); -- CONFIRMED
	}

	IEnumerator Resting () {
		Destroy (target.gameObject);
		hasEaten = true;
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
		target = null;
		FOV.SetActive(false);
		yield return new WaitForSeconds(restTime);
		FOV.SetActive(true);
		hasEaten = false;
	}

}
