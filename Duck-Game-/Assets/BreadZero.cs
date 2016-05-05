using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreadZero : MonoBehaviour {

    Image breadFill;

    void Start () {

        breadFill = GetComponent<Image>();
        breadFill.enabled = false;
    }
    void Update()
    {

        if (shootBullet.ammo == 0)
        {
            breadFill.enabled = false;
        }
        else
        {
            breadFill.enabled = true;
        }
    }
}
