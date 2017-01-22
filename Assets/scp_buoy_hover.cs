using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_buoy_hover : MonoBehaviour {

    public float MoveSpeed = 0f;

    public float frequency = 2f;  // Speed of sine movement
    public float magnitude = 1f;   // Size of sine movement
    private Vector3 axis;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        axis = transform.up;  // May or may not be the axis you want
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
