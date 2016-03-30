using UnityEngine;
using System.Collections;

public class secondsRotate : MonoBehaviour {

    float rSpeed, xRot, x;
    //Vector3 secondsHand;
    public GameObject secHand, hrHand, minHand;


    // Use this for initialization
    void Start () {
        rSpeed = 60f;
        
        
        //secHand.GetComponent<Vector3>();
        xRot = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        //xRot += rSpeed;
        //x = xRot;
        //transform. = new Vector3(hand.transform.x, hand.transform.y, hand.transform.z);                
        secHand.transform.Rotate(Vector3.left, Time.deltaTime * rSpeed);
        minHand.transform.Rotate(Vector3.left, Time.deltaTime * (rSpeed/60f));
        hrHand.transform.Rotate(Vector3.left, Time.deltaTime * ((rSpeed/60f)/60f));

    }
}
