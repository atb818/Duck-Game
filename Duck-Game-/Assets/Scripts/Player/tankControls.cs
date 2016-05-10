using UnityEngine;
using System.Collections;

public class tankControls : MonoBehaviour
{

    public float speed;
    public float turnSpeed;

    public Animator m_Animator;

    Rigidbody rb;
    Vector3 moveDir;

    public GameObject footsteps, backsteps;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //m_Animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.position = new Vector3 (transform.position.x, 1.67f, transform.position.z);

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.AddRelativeForce(Vector3.forward * speed);
            footsteps.SetActive(true);
        } else {
            footsteps.SetActive(false);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.AddRelativeForce(Vector3.forward * -speed/2f);
            backsteps.SetActive(true);
        } else {
            backsteps.SetActive(false);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        UpdateAnimation();
    }

    void UpdateAnimation()
    {

        m_Animator.SetFloat("Forward", Input.GetAxisRaw("Vertical"), 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", Input.GetAxis("Horizontal"), 0.1f, Time.deltaTime);
        m_Animator.SetBool("OnGround", true);

    }
}


