using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testHealth : MonoBehaviour {

    Image health;

	
	void Start () {
        health = GetComponent<Image>();
	}
	
	
	void Update () {

            health.fillAmount = shootBullet.power;

    }
}
