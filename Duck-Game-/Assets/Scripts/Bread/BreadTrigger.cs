using UnityEngine;
using System.Collections;

public class BreadTrigger : MonoBehaviour {

    bool TriggerBread = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(TriggerBread == true)
            {
                if(shootBullet.ammo >= 1) {
                    if (this.gameObject.tag == "Moldy")
                    {
                        BreadStatus.BStatus = "moldy";
                    }

                    if (this.gameObject.tag == "Soggy")
                    {
                        BreadStatus.BStatus = "soggy";
                    }

                    if (this.gameObject.tag == "Toasty")
                    {
                        BreadStatus.BStatus = "toasty";
                    }

                }
                

            }
        }
	
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            TriggerBread = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerBread = false;
        }

    }
}
