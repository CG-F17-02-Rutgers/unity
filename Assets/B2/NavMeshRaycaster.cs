using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Camera))]
public class NavMeshRaycaster : MonoBehaviour {

    public NavMeshAgent agent;

    private Camera rayCamera;

	// Use this for initialization
	void Start () {
        rayCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) {
                agent.destination = hitInfo.point;
            }

        }
	}
}
