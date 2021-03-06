﻿using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

    public static int check = 6;
    public int numberCheck = 6;

    public GameObject check0;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;
    public GameObject check5;
    public GameObject check6;

    public GameObject player;

    public GameObject Penta0;
    public GameObject Penta1;
    public GameObject Penta2;
    public GameObject Penta3;
    public GameObject Penta4;
    public GameObject Penta5;
    public GameObject Penta6;

    int ammoCheck;


    void Start()
    {
       
    }

        void Update() {

        //print(check);

        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.LoadLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            check++;
            numberCheck++;
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

        if (check == 5)
        {
            Penta5.SetActive(true);
        }

        if (check == 6)
        {
            Penta6.SetActive(true);
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
            Penta5.SetActive(false);
            Penta6.SetActive(false);


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
            Penta5.SetActive(false);
            Penta6.SetActive(false);

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
            Penta5.SetActive(false);
            Penta6.SetActive(false);

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
            Penta5.SetActive(false);
            Penta6.SetActive(false);

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
            Penta5.SetActive(false);
            Penta6.SetActive(false);

        }

        if (check == 5)
        {
            player.transform.position = check5.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(false);
            Penta1.SetActive(false);
            Penta2.SetActive(false);
            Penta3.SetActive(false);
            Penta4.SetActive(false);
            Penta5.SetActive(true);
            Penta6.SetActive(false);

        }

        if (check == 6)
        {
            player.transform.position = check6.transform.position;
            shootBullet.ammo = ammoCheck;
            Penta0.SetActive(false);
            Penta1.SetActive(false);
            Penta2.SetActive(false);
            Penta3.SetActive(false);
            Penta4.SetActive(false);
            Penta5.SetActive(false);
            Penta6.SetActive(true);

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

