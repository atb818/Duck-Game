using UnityEngine;
using System.Collections;

public class Randuck : MonoBehaviour {

    public Animator duckAnim;
    

    // Use this for initialization
    void Start () {
        duckAnim = GetComponent<Animator>();
        duckAnim.Play("Idle", 0, Random.Range(0f, 1f));
        duckAnim.SetFloat("AnimSpeed", Random.Range(.8f, 1.2f));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
