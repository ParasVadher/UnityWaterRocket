using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    float dragCoefficient = 0.345f;
    float effArea;
    float magnitude;
    Rigidbody rb;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        float effArea = CalculateFacingArea(mesh, this.transform.up);
        float dynamicPressure = 0.5f * 1.3f * rb.velocity.sqrMagnitude;
        magnitude = dragCoefficient * dynamicPressure * effArea;
        Vector3 dragForce = -rb.velocity.normalized * magnitude;
        rb.AddForce(dragForce, ForceMode.Force);
    }

    float CalculateFacingArea(Mesh mesh, Vector3 direction)
    {

        direction = direction.normalized;
        var triangles = mesh.triangles;
        var vertices = mesh.vertices;
        double sum = 0.0;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 corner = vertices[triangles[i]];
            Vector3 a = vertices[triangles[i + 1]] - corner;
            Vector3 b = vertices[triangles[i + 2]] - corner;
            float projection = Vector3.Dot(Vector3.Cross(b, a), direction);
            if (projection > 0f)
                sum += projection;
        }
        float result = (float)(sum / 2.0);
        return result;
    }
}