using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nozzletxt : MonoBehaviour {

    Text NText;
    // Use this for initialization
    void Start()
    {
        NText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        value = Mathf.Round(value * 10f) / 10f;
        NText.text = "Nozzle Diameter: " + value.ToString() + "mm";
    }
}
