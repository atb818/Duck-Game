using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockerUI : MonoBehaviour {

    public GameObject lockerUI;
    public static bool lockerUIon;

    // Use this for initialization
    void Start () {
        //lockerUI = GameObject.FindWithTag("LockerUI");
        lockerUI.SetActive(false);
        lockerUIon = false;
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Player")
        {
            lockerUI.SetActive(true);
            lockerUIon = true;
            print ("player near locker");
        }
	
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lockerUI.SetActive(false);
            lockerUIon = false;
        }

    }
}
