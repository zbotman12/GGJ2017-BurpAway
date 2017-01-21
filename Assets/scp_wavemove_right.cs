using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_wavemove_right : MonoBehaviour {

    public int wait = 0;
    public int wait_max = 121;
    public float move_speed = 0.01f;
    Vector3 direction_move = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (wait < (wait_max/2)) //start move to right
        {
            direction_move = new Vector3(move_speed, 0, 0); //set movement
        }
        if (wait >= (wait_max/2)) //start move to left
        {
            direction_move = new Vector3(-move_speed, 0, 0); //set movement
        }
        transform.Translate(direction_move); //perform movement
        wait += 1;
        if (wait == wait_max) { wait = 0; } //reset wait timer
    }
}
