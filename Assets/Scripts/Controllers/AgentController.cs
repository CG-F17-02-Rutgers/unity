using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour{
	NavMeshAgent agent;
	RaycastHit des;

	void Start(){
		agent = GetComponent<NavMeshAgent>();

	}

	void Update(){
		Debug.Log ("-------agent distance:" + agent.remainingDistance);
		if (Physics.OverlapSphere (agent.destination, 1).Length == 1) {
			agent.stoppingDistance = 50;
		} else {
			agent.stoppingDistance = 0;
		}

		if (agent.hasPath){
			agent.destination = des.point;
		}
		Debug.Log (agent.destination);
	}
	public void Move(Vector3 position){
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(position);
		if (Physics.Raycast(ray, out hit)){
			agent.destination = hit.point;
			des = hit;
		}
	}
}