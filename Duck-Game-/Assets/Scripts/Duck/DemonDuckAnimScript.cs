using UnityEngine;
using System.Collections;

public class DemonDuckAnimScript : MonoBehaviour
{

    public CharacterController Dcontroller;
    public Animator demonAnim;
    Vector3 demonVel;



    // Use this for initialization
    void Start()
    {
    	demonAnim.Play("Idle", 0, Random.Range(0f,1f));
    }

    // Update is called once per frame
    void Update()
    {
        demonVel = Dcontroller.velocity/Time.deltaTime;

        if (demonVel.magnitude < 1f)
        {
            demonAnim.SetBool("IsMoving", false);
            demonAnim.SetFloat("AnimSpeed", 1f);
        }
        else
        {
            demonAnim.SetBool("IsMoving", true);
            if (demonVel.magnitude >= 2f && demonVel.magnitude < 3f)
            {
                demonAnim.SetFloat("AnimSpeed", 1f);
            }
            if (demonVel.magnitude > 3f)
            {
                demonAnim.SetFloat("AnimSpeed", 1.5f);
            }
            else if (demonVel.magnitude < 1f)
            {
                demonAnim.SetBool("IsMoving", false);
                demonAnim.SetFloat("AnimSpeed", 1f);
            }
        }
    }
}
