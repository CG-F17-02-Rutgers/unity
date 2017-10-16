using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class AIController : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent navAgent;

    private int speedID;
    private int turningID;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        speedID = Animator.StringToHash("Speed");
        turningID = Animator.StringToHash("Turning");

        navAgent.updatePosition = false;
        navAgent.updateRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 deltaPosition = navAgent.nextPosition - transform.position;
        float forward = Vector3.Dot(deltaPosition, transform.forward);
        forward = forward / Time.deltaTime;
        float side = Vector3.Dot(deltaPosition, transform.right);
        side = side / Time.deltaTime;
        animator.SetFloat(turningID, side, 0.001f, Time.deltaTime);
        animator.SetFloat(speedID, forward, 0.001f, Time.deltaTime);
    }

    private void OnAnimatorMove() {

        //navAgent.steeringTarget
        transform.position = navAgent.nextPosition;
    }
}
