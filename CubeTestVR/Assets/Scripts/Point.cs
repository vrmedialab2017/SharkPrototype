using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Point pointB;
    public Vector3 pointPosition;

    private void Awake()
    {
        transform.LookAt(pointB.transform);
    }

    private void OnDrawGizmos()
    {
        pointPosition = transform.position;
        Gizmos.DrawSphere(pointPosition, 0.5F);
    }
}
