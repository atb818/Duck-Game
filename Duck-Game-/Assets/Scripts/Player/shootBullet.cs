using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {


    public GameObject bullet;
    public static float power = 0f;
    float torquePower;
    public static int ammo = 0;

    void Start() {
        //ammo = 0;
        //Below is for testing purposes:
        ammo = 10;
    }

    void Update()
    {


        power = Mathf.Clamp(power, 0f, 1f);

        torquePower = Random.Range(50, 500);

        if (Input.GetMouseButton(0))
        {

            if (power <= .20f)
            {
                power = .20f;
            }

            if (ammo > 0)
            {
                power += Time.deltaTime * .85f;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {

            if(ammo > 0)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                newBullet.GetComponent<Rigidbody>().AddTorque(transform.up * torquePower);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.up * power * 400);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power * 500);
                ammo--;
            }

            power = 0;
            
        }
    }
}
