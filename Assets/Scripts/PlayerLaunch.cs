﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLaunch : MonoBehaviour {

    Rigidbody2D rb;
    bool jumped = false;
    bool fall = false;
    public float turnAmmount;
    //new Vector3(Ycomp, Xcomp, hangTime)
    public int JumpInfoX;
    public int JumpInfoY;
    public float hangTime;
    [Range(0, 1)]
    public float power;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce (new Vector2(power * JumpInfoX, power * JumpInfoY));
            rb.AddTorque(turnAmmount);
            StartCoroutine(JumpTime());
        }

        if (jumped && rb.velocity.y <= 0)
        {
            rb.gravityScale = 0;
        }

        if(fall)
        {
            rb.gravityScale = 3;
        }
    }

    IEnumerator JumpTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            jumped = true;
            StartCoroutine(Hang());
        }
    }

    IEnumerator Hang()
    {
        while (true)
        {
            yield return new WaitForSeconds(power * hangTime);
            fall = true;
            jumped = false;
        }
    }
}
