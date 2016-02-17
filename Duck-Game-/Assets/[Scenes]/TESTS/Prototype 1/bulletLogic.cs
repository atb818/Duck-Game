using UnityEngine;
using System.Collections;

public class bulletLogic : MonoBehaviour
{

    Rigidbody rb;
    public int speed;
    int count;


    AudioSource[] sounds;
    AudioSource quack;
    AudioSource ow;

    



    void Start()
    {
        sounds = GetComponents<AudioSource>();
        quack = sounds[0];
        ow = sounds[1];

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }

    void Update ()
    {        
        if (count >= 3) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Duck")
        {
            //AudioSource.PlayClipAtPoint(quack.clip, transform.position);
            quack.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, quack.clip.length);

        }

        if (collision.gameObject.tag == "Student")
        {
            ow.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, ow.clip.length);

        }

        if (collision.gameObject.tag == "Teacher")
        {
            print("trouble");
            Destroy(gameObject);

        }

        count++;
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Classmate") || collision.collider.CompareTag("Teacher"))
        {
            Destroy(gameObject);
        }
    }
}
