using UnityEngine;
using System.Collections;

public class duckCollide : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            duckLocations.activeLocation = Random.Range(1, 6);
        }
    }
}
