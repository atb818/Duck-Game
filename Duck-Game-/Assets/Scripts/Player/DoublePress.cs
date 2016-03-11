using UnityEngine;
using System.Collections;

public class DoublePress : MonoBehaviour {

    //Originally written by Montraydavis

    private float clickCount = 0;
    private float mouseTimer = 0;

    Vector3 targetRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

            if (mouseTimer > 0 && clickCount == 1)
            {
                print("double press");
                transform.Rotate(0, 180, 0);
               
            }
            else
            {
                mouseTimer = 0.5f;
                clickCount += 1;
            }
        }

        if (mouseTimer > 0)
        {
            mouseTimer -= 1 * Time.deltaTime;
        }
        else
        {
            clickCount = 0;
        }
    }
}
