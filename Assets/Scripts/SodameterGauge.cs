using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (UnityEngine.UI.Image))]
public class SodameterGauge : MonoBehaviour
{
    public UnityEngine.UI.Image sodameter;
    public float fillAmt;
    public PlayerLaunch pLaunch;
    public float fillValue = 0;

    // Use this for initialization
    void Start ()
    {
        pLaunch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>();
        fillAmt = 0.0f;
        fillValue = 0.05f;
	}

    // Update is called once per frame
    void Update()
    {
        if (fillValue < 1)
        {
            fillValue += fillAmt;
            pLaunch.power = fillValue;
            sodameter.fillAmount = fillValue;
        }
    }

    public void fill()
    {
        fillAmt = 0.002f;
    }

    public void stopFill()
    {
        fillAmt = 0.0f;
    }
}
