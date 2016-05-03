using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockerUI : MonoBehaviour {

    GameObject lockerUI;
    public static bool lockerUIon;

    // Use this for initialization
    void Start () {
        lockerUI = GameObject.FindWithTag("LockerUI");
        lockerUI.SetActive(false);
        lockerUIon = false;
    }

    // Update is called once per frame
    void OnTriggerStay (Collider other) {
        if(other.gameObject.tag == "Player")
        {
            lockerUI.SetActive(true);
            lockerUIon = true;
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
