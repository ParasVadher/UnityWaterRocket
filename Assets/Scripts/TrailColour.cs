using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColour : MonoBehaviour
{
    LineRenderer lr;
    public Camera secondaryCamera;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        offset = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (secondaryCamera.enabled)
        {
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }

        var points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position - offset;
        lr.positionCount = 2;
        lr.SetPositions(points);


    }
}
