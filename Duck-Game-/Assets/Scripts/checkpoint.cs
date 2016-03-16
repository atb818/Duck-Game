using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

    public static int check;
    public int numberCheck = 0;

    public GameObject check1;
    //public GameObject check2;
   // public GameObject check3;

    public GameObject player;

    public GameObject closedBook;
    public GameObject openBook;


    void Update() {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.LoadLevel(0);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if(check == 1)
        {
            player.transform.position = check1.transform.position;
            closedBook.gameObject.SetActive(false);
            openBook.gameObject.SetActive(true);
        }

        if (check == 2)
        {
            //player.transform.position = check2.transform.position;
        }

        if (check == 3)
        {
            //player.transform.position = check3.transform.position;
        }


    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (check != numberCheck)
            {
                closedBook.gameObject.SetActive(false);
                openBook.gameObject.SetActive(true);
                check = numberCheck;
            }
                
            


        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position, transform.localScale);
        //Gizmos.color = new Color(0, 1, 0, 0.5f);
        //Gizmos.DrawLine(transform.position, CurrentCam.transform.position);
    }

}

