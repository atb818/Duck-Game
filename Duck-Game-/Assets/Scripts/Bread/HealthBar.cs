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

        if (health.fillAmount < .5f && health.fillAmount > .25f)
        {
            health.color = new Color(.93f, .76f, .04f, .52f);
        }

        if (health.fillAmount < .25f && health.fillAmount > .0f)
        {
            health.color = new Color(1, 0, 0, .52f);
        }




    }
}
