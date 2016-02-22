using UnityEngine;
using System.Collections;

public class QuackBack
 : MonoBehaviour {

 	AudioSource audio;

 	void Start (){
 		audio = GetComponent<AudioSource>();
 	}

 	void quackback(){
 		audio.Play();
 	}

}
