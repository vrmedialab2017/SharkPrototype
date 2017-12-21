using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool isMoving = false;
    public bool isRotating = false;
    public SharkPathfinding pathFinding;


    public IEnumerator MoveTowardsWaypoint(Vector3 PointA, Vector3 PointB, float time, GameObject toMove)
    {
        //Check if character is already moving..

        if (isMoving == false)
        {

            isMoving = true;

            float t = 0;
            //Move while time is still below 1




            while (t < 1)
            {
                t += Time.deltaTime / time;




                toMove.gameObject.transform.position = Vector3.Lerp(PointA, PointB, t);




                yield return 0;

            }



            //Rotate
            StartCoroutine(RotateTowardsClosestWayPoint(toMove.transform.eulerAngles, pathFinding.currentPoint.pointB.transform.eulerAngles, pathFinding.rotateTime, toMove));


            //Reset Routine
            isMoving = false;


        }

    }

    public IEnumerator RotateTowardsClosestWayPoint(Vector3 PointA, Vector3 PointB, float time, GameObject toMove)
    {
        //Check if character is already moving..
        //Debug.Log(PointA + " # " + PointB);
        if (isRotating == false)
        {

            isRotating = true;

            float t = 0;
            //Move while time is still below 1




            while (t < 1)
            {
                t += Time.deltaTime / time;

                //Check A is positive or negative, change B to be positive or negative if A is negative/positive.

                Vector3 normalized = new Vector3(
                    Mathf.LerpAngle(PointA.x, PointB.x, t),
                    Mathf.LerpAngle(PointA.y, PointB.y, t),
                    Mathf.LerpAngle(PointA.z, PointB.z, t));

                toMove.gameObject.transform.eulerAngles = normalized;



                yield return 0;

            }

            //Reset Routine
            isRotating = false;

            //Calculate new current point
            pathFinding.ReassignCurrentPoint(pathFinding.currentPoint.pointB);


            //Move the shark to the new target/point
            StartCoroutine(MoveTowardsWaypoint(pathFinding.currentPoint.transform.position, pathFinding.currentPoint.pointB.transform.position, pathFinding.time, pathFinding.shark));
        }

    }
}
