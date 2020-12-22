using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vtex : MonoBehaviour {

    Text VText;
	// Use this for initialization
	void Start () {
        VText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void textUpdate (float value)
    {
        value = Mathf.Round(value * 100f) / 100f;
        VText.text = "Volume: " + value.ToString() + "L"; 
	}
}
