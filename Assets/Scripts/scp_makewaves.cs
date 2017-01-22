using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_makewaves : MonoBehaviour {

    public GameObject wave_right1;
    public GameObject wave_left1;
    public GameObject wave_right2;
    public GameObject wave_left2;
    public GameObject wave_right3;
    public GameObject collisionBox;
    private int i = 0;
    public float xspacing;
    public float yspacing;
    void Start () {
        {
            for (i = 0; i <1000; i++) //make waves
            {
                Instantiate(wave_right1, new Vector3((i * xspacing), 0.4f, 0), Quaternion.identity, transform);
                Instantiate(wave_left1, new Vector3((i * xspacing), -2.5f, 0), Quaternion.identity, transform);
                Instantiate(wave_right2, new Vector3((i * xspacing), -5.5f, 0), Quaternion.identity, transform);
                Instantiate(wave_left2, new Vector3((i * xspacing), -8.5f, 0), Quaternion.identity, transform);
                Instantiate(wave_right3, new Vector3((i * xspacing), -11.5f, 0), Quaternion.identity, transform);
                Instantiate(collisionBox, new Vector3((i * xspacing), -5.5f, 0), Quaternion.identity, transform);



            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
