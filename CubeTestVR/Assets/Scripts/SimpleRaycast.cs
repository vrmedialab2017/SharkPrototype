using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycast : MonoBehaviour
{

    void FixedUpdate()
    {

        //hit data

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {

            //if this is the shark on the hitdata then do stuff
            print("Hit the shark");

            //measure eyes or something and interaction with heartbeat
        }
    }
}
