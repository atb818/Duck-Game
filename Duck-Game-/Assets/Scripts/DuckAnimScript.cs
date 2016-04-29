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

    }

    // Update is called once per frame
    void Update()
    {
        duckVel = Dcontroller.velocity/Time.deltaTime;

        if (duckVel.magnitude < .25f)
        {
            duckAnim.SetBool("IsMoving", false);
        }
        else
        {
            duckAnim.SetBool("IsMoving", true);
            if (duckVel.magnitude < 3f)
            {
                duckAnim.SetFloat("AnimSpeed", 2.5f);
            }
            else {
                duckAnim.SetFloat("AnimSpeed", 3.5f);
            }
        }
    }
}
