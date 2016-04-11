using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {


    public GameObject bullet;
    public GameObject moldy;
    public GameObject soggy;
    public GameObject toasty;
    public static float power = 0f;
    float torquePower;
    public static int ammo = 0;

    float counter = 0;


    void Start() {

        power = 0;

        ammo = 0;
        //Below is for testing purposes:
        //ammo = 10;
    }

    void Update()

    {
      
        power = Mathf.Clamp(power, 0f, 1f);

        torquePower = Random.Range(50, 500);

        if(goInside.canShoot == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                counter += .025f;

                if (power <= .20f)
                {
                    power = .20f;
                }

                power = Mathf.PingPong(counter, 1f);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                

                if (ammo > 0)
                {
                    if(BreadStatus.BStatus == "plain")
                    {
                        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                        newBullet.GetComponent<Rigidbody>().AddTorque(transform.up * torquePower);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * power * 400);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power * 400);
                    }

                    if (BreadStatus.BStatus == "moldy")
                    {
                        GameObject newBullet = Instantiate(moldy, transform.position, transform.rotation) as GameObject;
                        newBullet.GetComponent<Rigidbody>().AddTorque(transform.up * torquePower);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * power * 400);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power * 400);
                    }

                    if (BreadStatus.BStatus == "soggy")
                    {
                        GameObject newBullet = Instantiate(soggy, transform.position, transform.rotation) as GameObject;
                        newBullet.GetComponent<Rigidbody>().AddTorque(transform.right * torquePower);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * power * 550);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power * 350);
                    }

                    if (BreadStatus.BStatus == "toasty")
                    {
                        GameObject newBullet = Instantiate(toasty, transform.position, transform.rotation) as GameObject;
                        newBullet.GetComponent<Rigidbody>().AddTorque(transform.up * torquePower);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * power * 100);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power * 800);
                    }

                    if (BreadStatus.BStatus != "plain")
                    {
                        BreadStatus.BStatus = "plain";
                    }

                        ammo--;
                    
                }
                counter = 0;
                power = 0;



            }
        }


    }

      
}
