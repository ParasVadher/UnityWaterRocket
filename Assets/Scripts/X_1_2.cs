﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X_1_2 : MonoBehaviour
{
    public linescript ls;
    Text XmText;
    float label;

    // Use this for initialization
    void Start()
    {

        XmText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        label = Mathf.Round(0.5f * ls.maxTime * 1000f) / 1000f;
        XmText.text = label.ToString();
    }
}
