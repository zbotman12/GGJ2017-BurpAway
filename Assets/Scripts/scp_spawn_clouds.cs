using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_spawn_clouds : MonoBehaviour {

    public GameObject cloud1, cloud2, cloud3;
    private int i = 0;
    public float xspacing;
    public float yspacing;
    void Start () {
        {
            //spawn random cloud1
            for (i = 1; i <1000; i+=1) {
                Instantiate(cloud1, new Vector3((i * xspacing)+Random.Range(0,xspacing), Random.Range(0, yspacing),0), Quaternion.identity, transform);
            }
            //spawn random cloud2
            for (i = 1; i < 1000; i += 1) {
                Instantiate(cloud2, new Vector3((i * xspacing) + Random.Range(0, xspacing), Random.Range(0, yspacing), 0), Quaternion.identity, transform);
            }
            //spawn random cloud3
            for (i = 1; i < 1000; i += 1) {
                Instantiate(cloud3, new Vector3((i * xspacing) + Random.Range(0, xspacing), Random.Range(0, yspacing), 0), Quaternion.identity, transform);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
