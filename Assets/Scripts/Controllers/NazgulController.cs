using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NazgulController : MonoBehaviour, IAgent {
	private GameObject[] agents;
	private NavMeshAgent nazgulAgent;
	private NavMeshObstacle nazgulObstacle;

	private bool isMoving = false;
	private int waypointIndex;
	private Vector3 direction;
	private NavMeshPath navPath;

	public float detectionDistance = 10.0f;
	public float agentSpeed = 3.5f;

	// Use this for initialization
	void Start () {
		agents = GameObject.FindGameObjectsWithTag ("Agent");
		nazgulAgent = GetComponent<NavMeshAgent> ();
		nazgulObstacle = GetComponent<NavMeshObstacle> ();
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
			}
		}
	}

	void FixedUpdate () {
		if (isMoving) {
			Vector3 target = navPath.corners [waypointIndex] + Vector3.up;
			transform.position = Vector3.MoveTowards (transform.position, target, agentSpeed * Time.deltaTime);
			Vector3 diff = transform.position - target;
			Debug.Log (diff);
			if (diff.sqrMagnitude < 0.2f) {
				waypointIndex++;
				if (waypointIndex >= navPath.corners.Length) {
					isMoving = false;
					waypointIndex = 0;
				}
			}
		}
	}

	public void MoveTo(Vector3 position){
		NavMeshHit hit;
		// If the designated point is close enough to the navmesh
		nazgulAgent.enabled = true;
		if (NavMesh.SamplePosition (position, out hit, .1f, NavMesh.AllAreas)) {
			// Custom movement code!
			navPath = new NavMeshPath();
			nazgulAgent.CalculatePath (hit.position, navPath);
			if (navPath.status == NavMeshPathStatus.PathComplete) {
				nazgulAgent.enabled = false;
				isMoving = true;
				waypointIndex = 0;
			}
		}
	}
}
