using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DuckFOV : MonoBehaviour {

	void OnTriggerEnter(Collider player){
		if (player.CompareTag("Player")){
			SceneManager.LoadScene(0);
			print("SPOTTED");
		}
	}
	
}
