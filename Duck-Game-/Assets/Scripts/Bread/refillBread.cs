using UnityEngine;
using System.Collections;

public class refillBread : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

        if(other.gameObject.tag == "Bread" || other.gameObject.tag == "BreadPickup")
        {
            shootBullet.ammo++;
            Destroy(other.gameObject);
        }
	
	}
}
