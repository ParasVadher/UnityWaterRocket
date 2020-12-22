using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VCont : MonoBehaviour {

    public Slider slider;
    float origvalue;
    public NewBehaviourScript nbs;

    // Use this for initialization
    void Start()
    {
        origvalue = slider.value;
    }

    void Update()
    {

        if (nbs.check)
        {
            slider.interactable = false;
        }
        else
        {
            slider.interactable = true;
        }
    }

    public void Reset()
    {
        slider.value = origvalue;
    }
}
