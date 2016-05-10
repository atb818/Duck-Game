using UnityEngine;
using System.Collections;

public class AttractDuck2 : MonoBehaviour {

	//Trigger turned on via AttractDuck.cs

	public GameObject bread;
    Vector3 _bread, _duck;
    float proximity;

    void OnTriggerEnter(Collider duck)
    {
		if (duck.CompareTag("Duck")){

			duck.GetComponent<DuckCharacterController>().EatBread(bread.gameObject);
            
        }
	}



    void OnTriggerStay(Collider duck)
    {
        if (duck.CompareTag("Duck"))
        {
            _bread = bread.transform.position;
            _duck = duck.transform.position;
            duck.GetComponent<DuckCharacterController>().EatBread(bread.gameObject);
            proximity = Vector3.Distance(_bread, _duck);
            if (proximity < 2f)
            {
                StartCoroutine("BreadLife");
            }

        }
    }

    IEnumerator BreadLife()
    {
        yield return new WaitForSeconds(10);
        DestroyObject(bread);
    }
}
