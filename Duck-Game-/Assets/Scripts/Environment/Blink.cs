using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blink : MonoBehaviour {


    Image UI;

    // Use this for initialization
    void Start () {
        UI = GetComponent<Image>();
    }

    // Update is called once per frame

    void Update () {

        UI.color = new Color(1, 1, 1, Mathf.Abs(Mathf.Sin(Time.time * 3)));

    }
}
