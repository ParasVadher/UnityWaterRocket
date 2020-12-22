using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this directive is required when dealing with UI objects

public class Maxvaluecont : MonoBehaviour {

    public NewBehaviourScript nbs; //to access values from the rocket script
    float k;
    public Slider mSlider;
    float ogvalue;

    // Use this for initialization
    void Start () {
        ogvalue = mSlider.value;
    }
	
	// Update is called once per frame
	void Update () {
        k = nbs.V;
        mSlider.maxValue = 1000*k;

        if (nbs.check)
        {   //to prevent changes once the rocket has been launched
            mSlider.interactable = false;
        }
        else
        {
            mSlider.interactable = true;
        }
    }

    public void Reset()
    {
        //executes when the user presses the Reset button
        mSlider.value = ogvalue;
    }
}
