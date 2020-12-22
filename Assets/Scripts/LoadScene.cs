using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public Button button;
    public NewBehaviourScript nbs;
    public static bool check;


	// Update is called once per frame
	void FixedUpdate () {

        if (nbs.check && nbs.Thrust == 0 && nbs.test)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
		
	}

    public void OnClick ()
    {
        SceneManager.LoadScene("Test Results");
        check = true;
    }
}
