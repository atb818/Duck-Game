using UnityEngine;
using System.Collections;

public class duckLocations : MonoBehaviour {

    public GameObject duck;
    public GameObject target;
    public int location;
    static public int activeLocation;
  
    void Start () {
        activeLocation = Random.Range(1, 6);
	}
	
	
	void Update () {

        transform.LookAt(target.transform);

        if (activeLocation == location) {
            duck.transform.SetParent(gameObject.transform);
            duck.transform.position = gameObject.transform.position;

        }

       

	}

}
