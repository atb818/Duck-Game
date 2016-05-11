using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    Image health;
    public static float hitPoints = 1f;
    public static bool blink;


    void Start () {

        blink = false;
        hitPoints = 1;
        health = GetComponent<Image>();

    }
	
	
	void Update () {

        //print(hitPoints);

        

        if(hitPoints <= 0)
        {
            SceneManager.LoadScene(1);
        }

        health.fillAmount = hitPoints;

        if (health.fillAmount < .75f && health.fillAmount > .25f)
        {
            health.color = new Color(1, .9f, .45f, .52f);
        }

        if (health.fillAmount < .25f && health.fillAmount > .0f)
        {
            health.color = new Color(1, .2f, .2f, .52f);
        }

        if (health.fillAmount < .75f)
        {
            //blink code
            health.color = new Color(health.color.r, health.color.g, health.color.b, Mathf.Abs(Mathf.Sin(Time.time * 3 )));
        }
        else if (health.fillAmount < .25f)
        {
            //blink code
            health.color = new Color(health.color.r, health.color.g, health.color.b, Mathf.Abs(Mathf.Sin(Time.time * 10)));
        }




    }
}
