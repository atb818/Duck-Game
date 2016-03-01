using UnityEngine;

using System.Collections;
using UnityEngine.UI;

public class ammoCheck : MonoBehaviour {

    Text ammoLeft;

	void Start () {
        ammoLeft = GetComponent<Text>();
	}
	
	
	void Update () {
        ammoLeft.text = "" + shootBullet.ammo;
	
	}
}

