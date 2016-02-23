using UnityEngine;
using System.Collections;

public class waitAndDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Birth());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Birth()
    {
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }
}
