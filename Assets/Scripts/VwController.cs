using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VwController : MonoBehaviour {

    public Slider slider;
    public NewBehaviourScript BehaviourScript;
    float k;
    void Start () {
        k = BehaviourScript.V;
        slider.maxValue = k;
    }
	
	// Update is called once per frame
	void Update () {


    }
}
