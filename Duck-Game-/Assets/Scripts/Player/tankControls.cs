using UnityEngine;
using System.Collections;

public class tankControls : MonoBehaviour
{

    public float speed;
    public float turnSpeed;

    Rigidbody rb;
    Vector3 moveDir;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.AddRelativeForce(Vector3.forward * -speed);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

    }
}


