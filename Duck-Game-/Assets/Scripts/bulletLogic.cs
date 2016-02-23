using UnityEngine;
using System.Collections;

public class bulletLogic : MonoBehaviour
{

    Rigidbody rb;
    public int speed;
    public int speed2;

    AudioSource[] sounds;
    AudioSource quack;

    public GameObject player;

    float dist;
    float maxDist = 15f;

    bool offScreen;
    bool duckRadius = false;
    bool soundPlayed = false;

    void Start()
    {
        sounds = GetComponents<AudioSource>();
        quack = sounds[0];

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        rb.AddForce(transform.up * speed2);
    }

    void Update ()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist >= maxDist)
        {
            offScreen = true;
        }
        else if (dist <= maxDist)
        {
            offScreen = false;
        }


        if(duckRadius == true && offScreen == true)
        {
            soundPlayed = true;
        }

        if (soundPlayed == true)
        {
            //AudioSource.PlayClipAtPoint(quack.clip, transform.position);
            //GetComponent<Renderer>().enabled = false;
            //GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Duck")
        {
            duckRadius = true;
            
        }
    }

    }
