using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropTime : MonoBehaviour
{
    Text PTText;
    public linescript ls;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        PTText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t = ls.maxTime * 1000f;
        PTText.text = "Propulsive Period Duration: = " + t.ToString("F0") + "ms";
    }
}