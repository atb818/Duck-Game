using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartFade : MonoBehaviour {


    public Image screenFade;
    public float alpha;
    bool fading;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (fading == true)
        {
            screenFade.color = new Color(0, 0, 0, alpha);

            if (alpha < 1)
            {
                alpha += .5f * Time.deltaTime;
            }
            else
            {
                if (Application.loadedLevel == 0)
                {
                    Application.LoadLevel(1);


                }
            }
        }



        if (Input.anyKeyDown && Application.loadedLevel == 0)
        {
            fading = true;
        }

    }
}
