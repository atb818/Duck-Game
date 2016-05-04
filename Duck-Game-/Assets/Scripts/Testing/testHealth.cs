using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testHealth : MonoBehaviour {

    Image health;
    GameObject breadUI;


    void Start () {
        health = GetComponent<Image>();
        breadUI = GameObject.FindWithTag("BreadUI");
        breadUI.SetActive(false);
    }
	
	
	void Update () {
        
        if(shootBullet.display == true && LockerUI.lockerUIon == false)
        {
            breadUI.SetActive(true);
        }
        else
        {
            breadUI.SetActive(false);
        }


        if(shootBullet.ammo == 0)
        {
            health.fillAmount = 0;
        }
        else
        {
            health.fillAmount = shootBullet.power;
        }

    }
}
