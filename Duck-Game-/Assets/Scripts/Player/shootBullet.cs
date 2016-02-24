using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {


    public GameObject bullet;
    public GameObject boy;
	

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, boy.transform.rotation);
            newBullet.GetComponent<bulletLogic>().player = boy;
        }
    }
}
