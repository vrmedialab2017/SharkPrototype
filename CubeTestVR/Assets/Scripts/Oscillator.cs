using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    float timeCounter = 0;

    float speed;
    float width;
    float height;

	// Use this for initialization
	void Start () {
        speed = 2;
        width = 6;
        height = 8;
		
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime*speed;

        float x = Mathf.Cos (timeCounter)*width;
        float y = Mathf.Sin (timeCounter)*height;
        float z = 10;

        transform.position = new Vector3(x, y, z);

		
	}
}
