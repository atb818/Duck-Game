using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	/*
	Light light;
	float random;
	public float minIntensity = 0.25f;
	public float maxIntensity = 3f;

	void Start () {
		light = gameObject.GetComponent<Light>();
		random = Random.Range(0f, 65535f);
	}
	
	void Update () {
		float noise = Mathf.PerlinNoise(random, Time.time);
		light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
	}
	*/

	Light light;
	public float timeOn = 0.05f;
	public float timeOff = 0.5f;
	float changeTime = 0;

	void Start () {
		light = gameObject.GetComponent<Light>();
	}

	void Update () {
		if (Time.time > changeTime){
			light.enabled = !light.enabled;
			if (light.enabled) {
				changeTime = Time.time + timeOn;
			} else {
				changeTime = Time.time + timeOff;
			}
		}
	}
}
