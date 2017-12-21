using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDistance : MonoBehaviour {
    public float startingDistance = 100f;
	public float stableDistance = 10f;
    public float minDistance = 4f;
    public float distanceJump = 1.0f;
    public float jumpDelay = 1.0f;
    private float counter = 0.0f;
    public Transform objectToMove;
    private float objectZ;
	public bool _moving = true;
	public float heartRate = 60f;
	public float heartRateMax = 100f;
	public float heartRateMin = 40f;
	private bool getCloser = true;

	// Use this for initialization
	void Start () {
        objectZ = startingDistance;
		objectToMove.position = new Vector3 (objectToMove.position.x, objectToMove.position.y, objectZ);

    }
	
	// Update is called once per frame
	void Update () {
		if (heartRate > heartRateMax) {
			_moving = true;
			getCloser = false;
		} else if (heartRate < heartRateMin) {
			_moving = true;
			getCloser = true;
		} else {
			if (objectZ == stableDistance) {
				_moving = false;
			} else {
				_moving = true;
				if (objectZ < stableDistance) {
					getCloser = false;
				} else {
					getCloser = true;
				}
			}
		}

		if (_moving) {
			counter += Time.deltaTime;

			if (counter >= jumpDelay) {
				counter = 0;
				objectZ -= distanceJump;
				if (objectZ < minDistance) {
					objectZ = minDistance;
				}

				if (getCloser) {
					objectToMove.DOLocalMoveZ (objectZ, jumpDelay).SetEase(Ease.InOutBack);
				} else {
					objectToMove.DOLocalMoveZ (objectZ, jumpDelay * -1).SetEase(Ease.InOutBack);
				}
			}
		}
	}
}