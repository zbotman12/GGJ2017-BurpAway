using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flasj : MonoBehaviour
{

    public Image Keep;
    public Image Dont;
    public float speed;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Flash());
    }


    IEnumerator Flash()

    {
        yield return new WaitForSeconds(speed);
        if (Keep.enabled == true)
        {
            Keep.enabled = false;
            Dont.enabled = true;
        }
        else if (Dont.enabled == true)
        {
            Keep.enabled = true;
            Dont.enabled = false;
        }
            StartCoroutine(Flash());
    }
}
