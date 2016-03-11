using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    Image health;
    public static float hitPoints = 1f;

    void Start () {

        health = GetComponent<Image>();

    }
	
	
	void Update () {

        print(hitPoints);

        if(hitPoints <= 0)
        {
            SceneManager.LoadScene(0);
        }

        health.fillAmount = hitPoints;

    }
}
