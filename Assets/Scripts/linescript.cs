using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linescript : MonoBehaviour {
    
    //declaring variables
    List<float> ThrustList;
    List<float> TimeList;
    public float maxThrust;
    public float maxTime;
    int Length;
    public LineRenderer lr;
	
	// Update is called once per frame
	void Update ()
    {
        ThrustList = NewBehaviourScript.ThrustList; //Obtaining Thrust data from rocket propulsion script 
        TimeList = NewBehaviourScript.TimeList; //Obtaining time data from rocket propulsion script
        Length = ThrustList.Count;

        var points = new Vector3[Length];

        if (LoadScene.check)
        {   //when the scene is loaded
            FindMax();
            Normalise();
        }

        for (int i = 0; i < Length; i++)
        {
            //creating array with plot coordinates
            points[i] = new Vector3(TimeList[i] * 3000f, ThrustList[i], 0);
        }

        lr.positionCount = points.Length;
        lr.SetPositions(points);
    }

    void Normalise()
    {
        //for the curve to take up the same space on the axes for every particular relationship the data needs to be normalised
        for (int j = 0; j < Length; j++)
        {
            ThrustList[j] = 150f* ThrustList[j] / maxThrust;
            TimeList[j] = 0.12f* TimeList[j] / maxTime;

        }
    }

    void FindMax()
    {
        //this function iterates through the thrust and time lists to find the maximum value in each 
        for (int k = 0; k < Length; k++)
        {
            if (ThrustList[k] > maxThrust)
            {
                maxThrust = ThrustList[k];
            }

            if (TimeList[k] > maxTime)
            {
                maxTime = TimeList[k];
            }
        }
    }

}