﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Y_1_4 : MonoBehaviour
{
    public linescript ls;
    Text YmText;
    float label;

    // Use this for initialization
    void Start()
    {

        YmText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        label = Mathf.Round(0.25f * ls.maxThrust);
        YmText.text = label.ToString();
    }
}