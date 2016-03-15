using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    Image health;
    public static float hitPoints = 1f;

    void Start () {
        hitPoints = 1;
        health = GetComponent<Image>();

    }
	
	
	void Update () {

        //print(hitPoints);

        if(hitPoints <= 0)
        {
            SceneManager.LoadScene(0);
        }

        health.fillAmount = hitPoints;

    }
}
