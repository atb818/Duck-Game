using UnityEngine;
using System.Collections;

public class bulletLogic : MonoBehaviour
{

    Rigidbody rb;
    public int speed;
    int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }

    void Update ()
    {
        if (count == 3)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        count++;
    }
}
