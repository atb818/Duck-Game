using UnityEngine;
using System.Collections;

public class DuckAnimScript : MonoBehaviour
{

    public CharacterController Dcontroller;
    public Animator duckAnim;
    Vector3 duckVel;



    // Use this for initialization
    void Start()
    {
    	duckAnim.Play("Idle", 0, Random.Range(0f,1f));
    }

    // Update is called once per frame
    void Update()
    {
        duckVel = Dcontroller.velocity/Time.deltaTime;

        if (duckVel.magnitude < 1f)
        {
            duckAnim.SetBool("IsMoving", false);
            duckAnim.SetFloat("AnimSpeed", 1f);
        }
        else
        {
            duckAnim.SetBool("IsMoving", true);
            if (duckVel.magnitude >= 2f && duckVel.magnitude < 3f)
            {
                duckAnim.SetFloat("AnimSpeed", 2.5f);
            }
            if (duckVel.magnitude > 3f)
            {
                duckAnim.SetFloat("AnimSpeed", 3.5f);
            }
            else if (duckVel.magnitude < 1f)
            {
                duckAnim.SetBool("IsMoving", false);
                duckAnim.SetFloat("AnimSpeed", 1f);
            }
        }
    }
}
