﻿using UnityEngine;
using System.Collections;

public class lockerDoor : MonoBehaviour {

    bool doorOpen = false;
    bool opened = true;
    Quaternion newRotation;

    Vector3 startRot;


    void Start() {
        startRot = transform.eulerAngles;
    }

	void Update () {

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);

        if(doorOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!opened) {
                    opened = true;
                } 
                else if (opened)
                {
                    opened = false;
                }
                    
            }
        }
 

        if (opened == true)
        {
            newRotation = Quaternion.AngleAxis(startRot.y - 120, Vector3.up);
        }

        else if (opened == false)
        {

            newRotation = Quaternion.AngleAxis(startRot.y - 0, Vector3.up);
        }
     
                
            }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doorOpen = true;
            print("open");
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorOpen = false;
            print("close");
        }
    }

    public void changeDoor()
    {
        if (!opened)
        {
            opened = true;
        }
        else {
            opened = false;
        }
    }

}