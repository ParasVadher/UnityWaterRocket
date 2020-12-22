using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHeight : MonoBehaviour
{

    public NewBehaviourScript nbs;
    Text HText;
    public float Height;
    float zeroHeight;

    // Use this for initialization
    void Start()
    {
        HText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nbs.check == false)
        {
            zeroHeight = nbs.height;
        }

        Height = nbs.height - zeroHeight;

        HText.text = "Current Altitude = " + Height.ToString("F1") + "m";

    }
}
