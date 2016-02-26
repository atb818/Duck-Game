using UnityEngine;
using System.Collections;

public class duckCollide : MonoBehaviour {

    public GameObject target;

    void Update ()
    {
        transform.LookAt(target.transform);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            duckLocations.activeLocation = Random.Range(1, 6);
        }
    }
}
