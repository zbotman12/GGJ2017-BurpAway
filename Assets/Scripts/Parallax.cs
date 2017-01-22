using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour {

    ParallaxController parallaxController;
    SpriteRenderer sprRend;
    int sortingLayerValue;
	// Use this for initialization
	void Awake () {
        parallaxController = Camera.main.gameObject.GetComponent<ParallaxController>();
        sprRend = GetComponent<SpriteRenderer>();
        sortingLayerValue = SortingLayer.GetLayerValueFromID(sprRend.sortingLayerID);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(parallaxController.parallaxAmount * sortingLayerValue, 0, 0));
    }
}
