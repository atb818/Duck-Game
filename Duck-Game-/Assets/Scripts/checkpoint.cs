using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

    public static int check = 5;
    public int numberCheck = 0;

    public GameObject check0;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;

    public GameObject player;

    public GameObject Penta0;
    public GameObject Penta1;
    public GameObject Penta2;
    public GameObject Penta3;
    public GameObject Penta4;

    int ammoCheck;

    void Update() {

        print(check);

        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.LoadLevel(0);
        }

        if (check == 0)
        {
            Penta0.SetActive(true);
        }

        if (check == 1)
        {
            Penta1.SetActive(true);
        }

        if (check == 2)
        {
            Penta2.SetActive(true);
        }

        if (check == 3)
        {
            Penta3.SetActive(true);
        }

        if (check == 4)
        {
            Penta4.SetActive(true);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if(check == 0)
        {
            player.transform.position = check0.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(true);
            Penta1.SetActive(false);
            Penta2.SetActive(false);
            Penta3.SetActive(false);
            Penta4.SetActive(false);


        }

        if (check == 1)
        {
            player.transform.position = check1.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(false);
            Penta1.SetActive(true);
            Penta2.SetActive(false);
            Penta3.SetActive(false);
            Penta4.SetActive(false);

        }

        if (check == 2)
        {
            player.transform.position = check2.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(false);
            Penta1.SetActive(false);
            Penta2.SetActive(true);
            Penta3.SetActive(false);
            Penta4.SetActive(false);

        }

        if (check == 3)
        {
            player.transform.position = check3.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(false);
            Penta1.SetActive(false);
            Penta2.SetActive(false);
            Penta3.SetActive(true);
            Penta4.SetActive(false);

        }
        if (check == 4)
        {
            player.transform.position = check4.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(false);
            Penta1.SetActive(false);
            Penta2.SetActive(false);
            Penta3.SetActive(false);
            Penta4.SetActive(true);

        }




    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (check != numberCheck)
            {
                check = numberCheck;
                ammoCheck = shootBullet.ammo;

            }
            
            /* //ACTIVATE UNIVERSAL SET CHECKPOINT?
            public GameObject CPManager;
            CPManager.GetComponent<scriptname>().SetCheckpoint(this.transform, shootBullet.ammo);
            */
        }
    }

    /* //UNIVERSAL SET CHECKPOINT?
    public void SetCheckpoint(Transform cp, int ammo){
        closedBook.gameObject.SetActive(false);
        openBook.gameObject.SetActive(true);
        check = numberCheck;
        ammoCheck = shootBullet.ammo;
    }
    */

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position, transform.localScale);
        //Gizmos.color = new Color(0, 1, 0, 0.5f);
        //Gizmos.DrawLine(transform.position, CurrentCam.transform.position);
    }

}

