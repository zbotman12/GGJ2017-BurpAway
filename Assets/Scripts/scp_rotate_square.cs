using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_rotate_square : MonoBehaviour {

    public bool enable_rotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enable_rotate == true)
        {
            transform.Rotate(Vector3.back);
        }
    }
}
