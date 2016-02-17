﻿using UnityEngine;
using System.Collections;

public class FreeMovement : MonoBehaviour
{
    public float speed /*, slowDown*/;
    public Rigidbody rb;
    Vector3 pos;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
        speed = 2500f * Time.deltaTime;
        //slowDown = speed / 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.AddForce(speed, 0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.AddForce(-speed, 0, 0);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.AddForce(0, 0, speed);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.AddForce(0, 0, -speed);
        }
        //if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        //{
        //    speed--;
        //}
    }
}