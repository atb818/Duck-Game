using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreadStatus : MonoBehaviour {

    public static string BStatus = "plain";
    public Image moldy;
    public Image soggy;
    public Image toasty;

	void Start () {
        BStatus = "plain";
	}
	

	void Update () {

        if(BStatus == "plain")
        {
            moldy.enabled = false;
            soggy.enabled = false;
            toasty.enabled = false;
        }

        if (BStatus == "moldy")
        {
            moldy.enabled = true;
            soggy.enabled = false;
            toasty.enabled = false;
        }

        if (BStatus == "soggy")
        {
            moldy.enabled = false;
            soggy.enabled = true;
            toasty.enabled = false;
        }

        if (BStatus == "toasty")
        {
            moldy.enabled = false;
            soggy.enabled = false;
            toasty.enabled = true;
        }

    }
}
