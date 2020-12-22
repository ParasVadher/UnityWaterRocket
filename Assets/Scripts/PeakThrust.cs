using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PeakThrust : MonoBehaviour
{
    Text PTText;
    public linescript ls;

    // Start is called before the first frame update
    void Start()
    {
        PTText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        PTText.text = "Peak Thrust = " + ls.maxThrust.ToString("F1") + "N";
    }
}
