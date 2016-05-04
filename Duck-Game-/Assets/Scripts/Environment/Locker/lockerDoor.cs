using UnityEngine;
using System.Collections;

public class lockerDoor : MonoBehaviour {

    bool doorOpen = false;
    bool opened = true;
    Quaternion newRotation;
    public GameObject player;
    public static float dist;
    Vector3 startRot;
    //GameObject lockerUI;

    public float playerDist;


    void Start() {
        startRot = transform.eulerAngles;
        //lockerUI = GameObject.FindWithTag("LockerUI");
    }

	void Update () {

<<<<<<< HEAD
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (lockerUI != null){
            if(dist < playerDist)
            {
                lockerUI.SetActive(true);
            }
            else
            {
                lockerUI.SetActive(false);
            }
        }
=======
        //dist = Vector3.Distance(transform.position, player.transform.position);
       // if(dist < 7)
        //{
           // lockerUI.SetActive(true);
       // }
       // else
        //{
           // lockerUI.SetActive(false);
        //}
>>>>>>> 6a704d0fd8f7bc805088dbd6a7d48b5be8c11c29


        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);

        if(doorOpen == true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                
                if (!opened) {

                    opened = true;
                    //player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ | ~RigidbodyConstraints.FreezePositionX;

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
            //print("open");
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorOpen = false;
            //print("close");
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
