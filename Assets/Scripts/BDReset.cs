using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BDReset : MonoBehaviour {

    public Slider mSlider;
    float ogvalue;
    public NewBehaviourScript nbs;

    // Use this for initialization
    void Start () {
        ogvalue = mSlider.value;
    }

    void Update()
    {
        if (nbs.check)
        {
            mSlider.interactable = false;
        }
        else
        {
            mSlider.interactable = true;
        }
    }

    public void Reset()
    {
        mSlider.value = ogvalue;
    }
}
