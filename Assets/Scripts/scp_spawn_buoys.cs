using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_spawn_buoys : MonoBehaviour {

    public GameObject buoy100, buoy200, buoy300, buoy400, buoy500, buoy600, buoy700, buoy800, buoy900, buoy1000;
    private int i = 1;
    public float xspacing;
    public float yspacing;

    // Use this for initialization
    void Start()
    {
            Instantiate(buoy100, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy200, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy300, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy400, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy500, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy600, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy700, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy800, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy900, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform); i++;
            Instantiate(buoy1000, new Vector3((i * xspacing), yspacing, 0), Quaternion.identity, transform);

    }
	// Update is called once per frame
	void Update () {
		
	}
}
