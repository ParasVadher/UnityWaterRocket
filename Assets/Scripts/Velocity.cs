using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocity : MonoBehaviour
{
    public NewBehaviourScript nbs;
    Text vText;
    // Start is called before the first frame update
    void Start()
    {
        vText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        vText.text = "Velocity = " + nbs.v.ToString("F1") + "m/s";
    }
}
