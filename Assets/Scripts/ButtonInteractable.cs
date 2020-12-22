using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    public Button button;
    public NewBehaviourScript nbs;

    // Update is called once per frame
    void Update()
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