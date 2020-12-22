using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightTime : MonoBehaviour
{
    public NewBehaviourScript nbs;
    public CurrentHeight ch;
    Text Text;
    float FTime;
    float finalT;
    public bool land;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        land = (ch.Height <= 0.05);

        if (nbs.check && !nbs.test && !land)
        {
            FTime = Time.time - nbs.startTime;
            Text.text = "Flight Duration = " + FTime.ToString("F1") + "s";
        }

        else if(nbs.check && !nbs.test)
        {
            Text.text = "Flight Duration = " + FTime.ToString("F1") + "s";
        }

        else
        {
            Text.text = "Flight Duration = 0s";
        }
    }
}
