using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {
    public GameObject WaterRocket;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - WaterRocket.transform.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = WaterRocket.transform.position + offset;

    }
}
