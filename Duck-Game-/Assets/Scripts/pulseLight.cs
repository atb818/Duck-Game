using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pulseLight : MonoBehaviour {

    public Image skin;
private float transparency = 1f;
private bool transparencyGoingUp = false;
private bool currentlyFlashing = true;

    void Start() {
        StartCoroutine(flashTransparency(0f));
    }

	void Update () {

		//StartCoroutine (flashTransparency(5f));
	}

		IEnumerator flashTransparency(float waitTime)
	{
		Color tempColor = skin.material.color;
		tempColor.a = transparency;
		skin.material.color = tempColor;

		if(transparencyGoingUp)
		{
			transparency += 0.05f;
			if(transparency > 0.95f && transparency < 1.2f && currentlyFlashing) //if(transparency == 1)
				transparencyGoingUp = false;
		}
		else 
		{
			transparency -= 0.05f;
			if(transparency < 0.2f && transparency > 0.08f) //if(transparency == 0.1f)
				transparencyGoingUp = true;
		}
		

		yield return new WaitForSeconds(waitTime / 2); // 9 because it updates 9 times per direction, so waitTime == total time to go top to bot or bot to top
}
}