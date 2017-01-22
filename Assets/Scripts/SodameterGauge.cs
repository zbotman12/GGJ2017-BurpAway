using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (UnityEngine.UI.Image))]
public class SodameterGauge : MonoBehaviour
{
    public UnityEngine.UI.Image sodameter;
    public float fillAmt;
    public PlayerLaunch pLaunch;
    public float fillValue;

    // Use this for initialization
    void Start ()
    {
        pLaunch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>();
        fillAmt = 0.0f;
        fillValue = 0.05f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        fillValue += fillAmt;
        pLaunch.power = fillValue;
        sodameter.fillAmount = fillValue;
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
