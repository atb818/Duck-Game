using UnityEngine;
using System.Collections;

public class Raycast2 : MonoBehaviour {

	public LayerMask mask = 8;

	void Start () {
	
	}
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit = new RaycastHit();

        if (Physics.Raycast(ray, out rayHit, 1000f, mask.value)) {
            transform.LookAt(rayHit.point);
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);        
        }

	}
}
