using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkPathfinding : MonoBehaviour
{

    public Point currentPoint;

    public float time;
    public float rotateTime;
    public PlayerMovement playerMovement;

    public GameObject shark;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(playerMovement.MoveTowardsWaypoint(shark.transform.position, currentPoint.pointB.transform.position, time, shark));
    }

    public void ReassignCurrentPoint(Point point)
    {
        currentPoint = point;
    }


    //Assign a target

    //Move to the target <- different script

    //Assign a new target

    // ETC
}
