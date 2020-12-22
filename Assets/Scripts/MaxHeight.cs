using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHeight : MonoBehaviour {

    public NewBehaviourScript nbs;
    Text MHText;
    float Height;
    float maxHeight;
    float zeroHeight;

    // Use this for initialization
    void Start () {
        MHText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        
        if (nbs.check == false)
        {
            zeroHeight = nbs.height;
        }

        Height = nbs.height - zeroHeight;

        if (maxHeight < Height)
        {
            maxHeight = Height;
        }

        MHText.text = "Maximum Altitude = " + maxHeight.ToString("F1") + "m";
        
    }

    public void Reset()
    {
        maxHeight = 0f;
    }
}
