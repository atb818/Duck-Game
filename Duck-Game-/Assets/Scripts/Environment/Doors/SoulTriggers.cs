using UnityEngine;
using System.Collections;

public class SoulTriggers : MonoBehaviour {

	public GameObject door1, door2, collider;
	public float d1Rot, d2Rot;

	public bool twoDoors;
	bool open = false;
	public bool isCollider = false;


	Quaternion newRot1, newRot2;
    Vector3 startRot1, startRot2;

	void Start () {

		startRot1 = door1.transform.eulerAngles;

		if (!twoDoors){
			door2 = null;
		}  else {
			startRot2 = door2.transform.eulerAngles;
		}
	
	}
	
	void Update () {
        door1.transform.rotation = Quaternion.Slerp(transform.rotation, newRot1, .05f);

        if (twoDoors){
        	door2.transform.rotation = Quaternion.Slerp(transform.rotation, newRot2, .05f);
    	}

        if (open){
        	//newRot1 = Quaternion.AngleAxis(startRot1.y + d2Rot, Vector3.up);
			door1.transform.eulerAngles = new Vector3 (0,d1Rot,0);
        	if (twoDoors){
        		newRot2 = Quaternion.AngleAxis(startRot2.y + d2Rot, Vector3.up);
        	}
        }      
	}

	void OnTriggerEnter(Collider soul){
		if (soul.CompareTag("Player")){
			open = true;
			if (isCollider){
				collider.SetActive(false);
			}
		}
	}
}
