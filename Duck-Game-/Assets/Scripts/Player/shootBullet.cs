using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {


    public GameObject bullet;
    public float fireRate = 0.5f;
    private float nextFire = 0.0F;
    public float power = 0f;
    float torquePower;
    public static int ammo = 0;

    void Update()
    {
        torquePower = Random.Range(50, 500);
    }

    void FixedUpdate()
    {

        power = Mathf.Clamp(power, .25f, 1f);

        if (Input.GetButton("Fire1") && ammo > 0)
        {
            
            power += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1") && ammo > 0)
        {
            nextFire = Time.time + fireRate;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().AddTorque(transform.up * torquePower);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.up * power * 400);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power * 500);

            power = 0;
            ammo--;
        }
    }
}
