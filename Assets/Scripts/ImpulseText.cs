using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpulseText : MonoBehaviour {

    Text IText;
    List<float> ThrustList;
    public float impulse;

    // Use this for initialization
    void Start()
    {
        IText = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate () {
        ThrustList = NewBehaviourScript.ThrustList;
        IText.text = "Impulse = " + impulse.ToString("F1") + "Ns";

        if (LoadScene.check)
        {
            Impulse();
            LoadScene.check = false;
        }
    }

    public void Impulse()
    {
        impulse = 0.0f;
        for (int i = 0; i < ThrustList.Count; i++)
        {
            impulse += ThrustList[i] * Time.fixedDeltaTime;
        }

        impulse = Mathf.Round(impulse * 1000f) / 1000f;
    }

}
