using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {

    private LineRenderer lr;
    private Quaternion parentRot;
    public GameObject raySpawn, rayClone, boy;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        boy = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButtonDown(1)) {*/ Fire(); //}
        
	}

    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(raySpawn.transform.position, raySpawn.transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(raySpawn.transform.localPosition.x, raySpawn.transform.localPosition.y, hit.distance*17));
                Debug.Log(hit.distance);
                parentRot = (boy.transform.rotation);
                float pRotY = (parentRot.y * -1);
                parentRot = new Quaternion(raySpawn.transform.rotation.x, pRotY, raySpawn.transform.rotation.z, raySpawn.transform.rotation.w);
                Instantiate(rayClone, hit.point, parentRot);
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(raySpawn.transform.localPosition.x, raySpawn.transform.localPosition.y, 5000));
        }

    }
}
