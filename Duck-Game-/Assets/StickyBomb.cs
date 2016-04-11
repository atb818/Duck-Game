using UnityEngine;
using System.Collections;

public class StickyBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision collision)
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
}
