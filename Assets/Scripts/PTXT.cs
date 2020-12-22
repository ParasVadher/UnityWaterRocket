using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PTXT : MonoBehaviour {

    Text PText;
    // Use this for initialization
    void Start()
    {
        PText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        
        PText.text = "Pressure: " + value.ToString() + "Pa";
    }
}
