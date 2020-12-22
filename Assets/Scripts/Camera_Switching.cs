using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Switching : MonoBehaviour {

    public Camera mainCamera;
    public Camera secondaryCamera;

    // Use this for initialization
    void Start () {
        //game starts with main camera active
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }
	
	public void Switch()
    {
        mainCamera.enabled = !mainCamera.enabled;
        secondaryCamera.enabled = !secondaryCamera.enabled;
    }
}
