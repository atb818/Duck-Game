using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testHealth : MonoBehaviour {

    Image health;

	
	void Start () {
        health = GetComponent<Image>();
	}
	
	
	void Update () {


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
