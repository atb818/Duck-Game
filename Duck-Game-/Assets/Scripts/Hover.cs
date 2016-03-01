using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {

	public bool Move = true; 
	public Vector3 MoveVector = Vector3.up;
	public float MoveRange = .005f; 
	public float MoveSpeed = 3;  
	Vector3 startPosition; 

	void Start(){
		startPosition = transform.position;
	}
	void Update()
	{
		if(Move)
			transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.time * MoveSpeed));
	
	}
}
