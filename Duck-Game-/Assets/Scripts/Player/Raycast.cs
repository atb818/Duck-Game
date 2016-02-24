using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit = new RaycastHit();

        if (Physics.Raycast(ray, out rayHit, 1000f))
        {
            if (rayHit.collider.tag == "Ground")
            {
                transform.LookAt(rayHit.point);
                transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
            }
            else
            {
                
            }
        }

    }
}
