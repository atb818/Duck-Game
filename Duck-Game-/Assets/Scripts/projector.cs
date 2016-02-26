using UnityEngine;
using System.Collections;

public class projector : MonoBehaviour {



    public float power = 10.0F;

    Vector3 StartPos;

    void Start() {
        StartPos = GetComponent<Transform>().position;
    }

	void FixedUpdate () {

        if (Input.GetButton("Fire1"))
        {
            power += Time.deltaTime;
            GetComponent<Rigidbody>().AddForce(transform.forward * power * 10);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            transform.position = StartPos;
        }

    }


}
