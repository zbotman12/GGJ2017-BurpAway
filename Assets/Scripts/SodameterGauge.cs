using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (UnityEngine.UI.Image))]
public class SodameterGauge : MonoBehaviour
{
    public UnityEngine.UI.Image sodameter;
    public float fillAmt;

    // Use this for initialization
    void Start ()
    {
        fillAmt = 0.0f;
        sodameter.fillAmount = 0.2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        sodameter.fillAmount += fillAmt;
	}

    public void fill()
    {
        fillAmt = 0.005f;
    }

    public void stopFill()
    {
        fillAmt = 0.0f;
    }
}
