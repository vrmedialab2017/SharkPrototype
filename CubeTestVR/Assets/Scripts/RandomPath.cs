using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPath : MonoBehaviour 
{
    public bool autoPopulateWaypoints;
    public List<Transform> targets;
    [SerializeField]
    Transform _destination;
    NavMeshAgent _navAgent;
	// Use this for initialization
	void Start () {
        _navAgent = GetComponent<NavMeshAgent>();
        if (_navAgent == null)
        {
            Debug.LogError("The nav mesh agent is not attached to " + gameObject.name);
        }
        else
        {
            if (autoPopulateWaypoints)
            {
                GameObject npcpoints = GameObject.Find("NPCWaypoints");
                if (npcpoints != null)
                {
                    targets = new List<Transform>();
                    foreach (Transform grandchild in npcpoints.gameObject.transform)
                    {
                        targets.Add(grandchild);
                    }
                }
                else
                {
                    Debug.Log("cant find NPCWaypoints");
                }
            }
            SetDestination();
        }
	}
	
    void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetvector = _destination.transform.position;
            _navAgent.SetDestination(targetvector);
        }
	}

    void Update()
    {
        if (_navAgent.remainingDistance<=1.5f)
        {
            int rnd = Random.Range(0, targets.Count);
            Vector3 targetvector = targets[rnd].position;
            _navAgent.SetDestination(targetvector);
        }
    }
}
