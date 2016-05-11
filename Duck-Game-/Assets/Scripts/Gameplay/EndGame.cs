using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {

    public Image screenFade;
    public float alpha;
    bool fading;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider player) {
		if (player.CompareTag("Player")){
			print ("DuckBoy escaped!");

            screenFade.color = new Color(0, 0, 0, alpha);

            if (alpha < 1)
            {
                alpha += .5f * Time.deltaTime;
            }
            else
            {
                if (Application.loadedLevel == 1)
                {
                    Application.LoadLevel(2);


                }
            }

        }
	}
}
