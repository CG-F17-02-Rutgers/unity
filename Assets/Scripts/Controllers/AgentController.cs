using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour{
    NavMeshAgent agent;
	Vector3 des;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
		if (agent.hasPath){
			Move (des);
		}
    }
    public void Move(Vector3 position){
        RaycastHit hit;
		des = position;
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hit)){
            agent.destination = hit.point;
        }
    }
}