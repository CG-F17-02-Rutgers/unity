using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour, IAgent {
	NavMeshAgent agent;
	//RaycastHit des;
	public Vector3 destination;

	void Start(){
		agent = GetComponent<NavMeshAgent>();

	}

	void Update(){
		/*
		Debug.Log ("-------agent distance:" + agent.remainingDistance);
		if (Physics.OverlapSphere (agent.destination, 0.1f).Length == 1) {
			agent.stoppingDistance = 50;
		} else {
			agent.stoppingDistance = 0;
		}

		if (agent.hasPath){
			agent.destination = des.point;
		}
		Debug.Log (agent.destination);
		*/
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (destination, 0.25f);
	}

	public void MoveTo(Vector3 position){
		NavMeshHit hit;
		// If the designated point is close enough to the navmesh
		if (NavMesh.SamplePosition (position, out hit, .1f, NavMesh.AllAreas)) {
			destination = hit.position;
			agent.SetDestination (hit.position);
		}
	}
}