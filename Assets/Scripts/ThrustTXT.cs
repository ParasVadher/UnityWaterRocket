using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustTXT : MonoBehaviour {

    public NewBehaviourScript nbs;
    Text ThrText;
    float thrust;
    // Use this for initialization
    void Start()
    {

        ThrText = GetComponent<Text>();

    }

    // Update is called once per frame
    void FixedUpdate () {
        if(thrust< nbs.Thrust)
        {
            thrust = nbs.Thrust;
        }

        thrust= Mathf.Round(thrust * 10f) / 10f;
        ThrText.text = "Peak Thrust = " + thrust +"N";
	}

    public void Reset()
    {
        thrust = 0f;
    }
}
