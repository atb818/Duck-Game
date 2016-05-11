using UnityEngine;
using System.Collections;

public class ResetButtons : MonoBehaviour
{

    void Start ()
    {
        Cursor.visible = false;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
 
    void Update()
    {

        if (Input.GetButtonDown("CheckpointA") && Input.GetButtonDown("CheckpointB"))
            {
                Application.LoadLevel(1);
            }

            if (Input.GetButtonDown("ResetA") && Input.GetButtonDown("ResetB"))
            {
                Application.LoadLevel(0);
            }

        }
    }
