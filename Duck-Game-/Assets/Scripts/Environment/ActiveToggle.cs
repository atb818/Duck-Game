using UnityEngine;
using System.Collections;

public class ActiveToggle : MonoBehaviour {

	public GameObject next;
	public GameObject prev;
	public bool togglePrev;
	public bool toggleNext;

	void Start () {
		//next.SetActive(false);
	}
	
	void Update () {
	
	}

	void OnTriggerEnter (Collider player) {
		if (player.CompareTag("Player")){
			if (toggleNext){
				next.SetActive(true);
			}
			if (togglePrev){
				prev.SetActive(false);
			}
		}
	}
}
