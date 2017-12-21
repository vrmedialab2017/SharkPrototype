using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PivotScript : MonoBehaviour {
	public Transform myObject;
	public Transform objectToFollow;
	public float speed = 0.5f;
	public bool switchDirection = false;

	// Use this for initialization
	void Start () {
		if (objectToFollow != null) {
			Vector3 newPosition = objectToFollow.transform.position;
			newPosition.y = myObject.transform.position.y;
			myObject.transform.position = newPosition;
		}
	}

//	myObject.DOLocalMoveY (20f targetposition, 3f time it takes to get there).SetEase (Ease.InOutCirc);
	
	// Update is called once per frame
	void Update () {
		if(myObject != null) {
			if (switchDirection == false) {
				myObject.Rotate (new Vector3 (0, speed, 0));//(myObject.eulerAngles +
			} else {
				myObject.Rotate (new Vector3 (0, speed *-1, 0));//(myObject.eulerAngles +
			}
		}
		if (objectToFollow != null) {
			Vector3 newPosition = objectToFollow.transform.position;
			newPosition.y = myObject.transform.position.y;
			myObject.transform.position = newPosition;
		}
	}
}
