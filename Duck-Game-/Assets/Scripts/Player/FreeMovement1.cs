using UnityEngine;
using System.Collections;

public class FreeMovement1 : MonoBehaviour
{
    public float speed , spin/*, slowDown*/;
    public Rigidbody rb;
    Vector3 pos;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
        speed = 3000f * Time.deltaTime;
        //slowDown = speed / 4;
        spin = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(Vector3.left *spin* Time.deltaTime);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(Vector3.left *spin* Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.AddRelativeForce(Vector3.forward * -speed);
        }
        //if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        //{
        //    speed--;
        //}
    }
}
