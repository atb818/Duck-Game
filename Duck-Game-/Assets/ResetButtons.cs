using UnityEngine;
using System.Collections;

public class ResetButtons : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetButtonDown("CheckpointA") && Input.GetButtonDown("CheckpointB"))
        {
            Application.LoadLevel(1);
        }

        if (Input.GetButtonDown("ResetA") && Input.GetButtonDown("ResetB"))
        {
            Application.LoadLevel(0);
        }

    }
}
