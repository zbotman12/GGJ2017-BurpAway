using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_draw_title : MonoBehaviour {

    public Object self;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //draw title text
    void OnGUI()
    {
 
        GUI.Label(new Rect(400, 200, 800, 400), "Burpaway");

        // Make a background box
        //GUI.Box(new Rect(20, 20, 100, 40), "Loader Menu");
    }
}
