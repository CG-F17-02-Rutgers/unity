using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NazgulController : MonoBehaviour {
	private GameObject[] agents;
	private NavMeshAgent nazgulAgent;
	public float detectionDistance = 10.0f;

	// Use this for initialization
	void Start () {
		agents = GameObject.FindGameObjectsWithTag ("Agent");
		nazgulAgent = GetComponent<NavMeshAgent> ();
		//nazgulAgent.radius = detectionDistance;
		//nazgulAgent.avoidancePriority = 10;
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, detectionDistance);
	}

	// Update is called once per frame
	void Update () {
		
		// If the other agents are sufficiently close to this one
		foreach (GameObject o in agents) {
			if ((o.transform.position - transform.position).sqrMagnitude < (detectionDistance * detectionDistance)) {
				o.GetComponent<NavMeshAgent>().Move((o.transform.position - transform.position).normalized);
			}
		}
	}
}
