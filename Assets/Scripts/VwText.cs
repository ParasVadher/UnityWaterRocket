using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VwText : MonoBehaviour {

    Text VwaText;

    void Start()
    {
        VwaText = GetComponent<Text>();
    }

 
    public void textUpdate(float value)
    {
        value = Mathf.Round(value * 100f) / 100f;
        VwaText.text = "Water Volume: " + value.ToString() +" L";
    }
}
