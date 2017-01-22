using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBarMovement : MonoBehaviour
{
    float startTime;
    RectTransform trans;
    // Use this for initialization
	void Start ()
    {
        trans = GetComponent<RectTransform>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Time Passed: " + (Time.time - startTime));
        if ((Time.time - startTime) <= 6f)
        {
            float scaleFactor = 1 - ((Time.time - startTime) / 12f);
            scaleFactor = (trans.localScale.y <= scaleFactor) ? trans.localScale.y : scaleFactor;
            Debug.Log("Scale Factor: " + scaleFactor);
            trans.localScale = new Vector3(trans.localScale.x, scaleFactor, trans.localScale.z);
        }
	}
}
