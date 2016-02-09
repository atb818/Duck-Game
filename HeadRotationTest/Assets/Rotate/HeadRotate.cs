using UnityEngine;
using System.Collections;

public class HeadRotate : MonoBehaviour {

    Vector3 mousePos;
    float playerRotationAngle;
    public GameObject targetPlayer;
    Vector3 objectPos;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.z;
        //playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(new Vector3(0, playerRotationAngle, 0));
    }
}
