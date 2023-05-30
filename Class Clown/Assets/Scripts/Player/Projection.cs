using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Interact inter;
    // Number of points on the line
    public int numPoints = 50;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {

        GameObject obj = inter.GetHeld;
        if(obj != null)
        {
            lineRenderer.positionCount = numPoints;
            List<Vector3> points = new List<Vector3>();
            Vector3 startingPosition = obj.transform.position;
            Vector3 startingVelocity = obj.transform.forward * inter.GetThrowPower + obj.transform.up * 2;
            for (float t = 0; t < numPoints; t += timeBetweenPoints)
            {
                Vector3 newPoint = startingPosition + t * startingVelocity;
                newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
                points.Add(newPoint);

                if (Physics.OverlapSphere(newPoint, .2f, CollidableLayers).Length > 0)
                {
                    lineRenderer.positionCount = points.Count;
                    break;
                }
            }

            lineRenderer.SetPositions(points.ToArray());
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }
}