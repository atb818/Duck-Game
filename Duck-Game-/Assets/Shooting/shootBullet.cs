using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {


    public GameObject bullet;
    public GameObject boy;
	

	void Update () {

        if (Input.GetMouseButtonDown(0))
            Instantiate(bullet, transform.position, boy.transform.rotation);

    }
}
