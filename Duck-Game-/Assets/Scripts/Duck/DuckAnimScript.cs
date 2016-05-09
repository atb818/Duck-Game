using UnityEngine;
using System.Collections;

public class DuckAnimScript : MonoBehaviour
{

    public CharacterController Dcontroller;
    public Animator duckAnim;
    Vector3 duckVel, lastPos;



    // Use this for initialization
    void Start()
    {
        //duckAnim.Play("Idle", 0, Random.Range(0f,1f));
        duckAnim.SetBool("IsMoving", false);
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        duckVel = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
        duckAnim.SetFloat("velocity", duckVel.magnitude);

        if (duckVel.magnitude > 1f)
        {
            duckAnim.SetBool("IsMoving", true);
            if (duckVel.magnitude > 2f && duckVel.magnitude < 3f)
            {
                duckAnim.SetFloat("AnimSpeed", 2.5f);
            }
            if (duckVel.magnitude > 3f)
            {
                duckAnim.SetFloat("AnimSpeed", 3.5f);
            }
        }
        else
        {
           
            duckAnim.SetBool("IsMoving", false);
            duckAnim.SetFloat("AnimSpeed", 1f);
        }
    }
}
