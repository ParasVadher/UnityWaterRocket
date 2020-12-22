using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleTxt : MonoBehaviour {

    Text BText;
    // Use this for initialization
    void Start()
    {
        BText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        value = Mathf.Round(value * 10f) / 10f;
        BText.text = "Bottle Diameter: " + value.ToString() + "cm";
    }
}
