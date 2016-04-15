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

        if (other.gameObject.tag == "Moldy")
        {
            BreadStatus.BStatus = "moldy";
            shootBullet.ammo++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Soggy")
        {
            BreadStatus.BStatus = "soggy";
            shootBullet.ammo++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Toasty")
        {
            BreadStatus.BStatus = "toasty";
            shootBullet.ammo++;
            Destroy(other.gameObject);
        }


    }
}
