using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticTestScript : MonoBehaviour
{
    public Button button;
    public NewBehaviourScript nbs;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (nbs.check)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
