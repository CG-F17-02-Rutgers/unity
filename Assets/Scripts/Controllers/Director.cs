using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {
	
	private List<IAgent> selectedAgents;

	private Collider[] movingOb = new Collider[2];
	private bool[] chosenOb = new bool[2];
	public int speed;
    // Use this for initialization
    void Start () {
		selectedAgents = new List<IAgent> ();
		//initialize movableobstacles
		//movingOb [0] = GameObject.FindGameObjectWithTag ("movingOb1").GetComponent<Collider> (); chosenOb[0]=false;
		//movingOb [1] = GameObject.FindGameObjectWithTag ("movingOb2").GetComponent<Collider> (); chosenOb[1] = false;
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo);

            if (didHit){
				GameObject selectedObject = rhInfo.collider.gameObject;
				if(rhInfo.collider.name.Equals("MovableObstacle1")){
					if (chosenOb [0] == true) {
						chosenOb [0] = false;
						movingOb [0].GetComponent<Rigidbody> ().GetComponent<Renderer> ().material.color = Color.white;
					} else {
						chosenOb[0] = true;
						movingOb[0].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
					}
				}
				if(rhInfo.collider.name.Equals("MovableObstacle2")){
					if (chosenOb [1] == true) {
						chosenOb [1] = false;
						movingOb [1].GetComponent<Rigidbody> ().GetComponent<Renderer> ().material.color = Color.white;
					} else {
						chosenOb[1] = true;
						movingOb[1].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
					}
				}

				IAgent agent = (IAgent) selectedObject.GetComponent(typeof(IAgent));
				if (agent != null) {
					if(selectedAgents.Contains(agent)) {
						// remove it from the list, change color back to white
						selectedObject.GetComponent<Renderer>().material.color = Color.white;
						selectedAgents.Remove(agent);
					} else {
						// add it to the list
						selectedObject.GetComponent<Renderer>().material.color = Color.red;
						selectedAgents.Add(agent);
					}

                }
            }
            else{
                //Debug.Log("clicked on EmptySpace");
            }

        }

        if (Input.GetMouseButtonDown(1)){
			Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rhInfo;
			bool didHit = Physics.Raycast(toMouse, out rhInfo);
			if (didHit) {
				// we hit an object. check if we can navigate to it
				foreach (IAgent a in selectedAgents) {
					a.MoveTo (rhInfo.point);
				}
			}
        }

		if(Input.GetKey(KeyCode.A)){
			if (chosenOb [0] == true) {
				if(movingOb[0].transform.position.x >= -330) {
					movingOb[0].transform.position += Vector3.left * speed * Time.deltaTime;
				}
			}
			if (chosenOb [1] == true) {
				if(movingOb[1].transform.position.x >= -330) {
					movingOb[1].transform.position += Vector3.left * speed * Time.deltaTime;
				}
			}
		}
		if(Input.GetKey(KeyCode.D)){
			if (chosenOb [0] == true) {
				if(movingOb[0].transform.position.x <= 330) {
					movingOb[0].transform.position += Vector3.right * speed * Time.deltaTime;
				}
			}
			if (chosenOb [1] == true) {
				if(movingOb[1].transform.position.x <= 330) {
					movingOb[1].transform.position += Vector3.right * speed * Time.deltaTime;
				}
			}
		}
		if(Input.GetKey(KeyCode.W)){
			if (chosenOb [0] == true) {
				if(movingOb[0].transform.position.z <= 284) {
					movingOb[0].transform.position += Vector3.forward * speed * Time.deltaTime;
				}
			}
			if (chosenOb [1] == true) {
				if(movingOb[1].transform.position.z <= 284) {
					movingOb[1].transform.position += Vector3.forward * speed * Time.deltaTime;
				}
			}
		}
		if(Input.GetKey(KeyCode.S)){
			if (chosenOb [0] == true) {
				if(movingOb[0].transform.position.z >= -276) {
					movingOb[0].transform.position += Vector3.back * speed * Time.deltaTime;
				}
			}
			if (chosenOb [1] == true) {
				if(movingOb[1].transform.position.z >= -276) {
					movingOb[1].transform.position += Vector3.back * speed * Time.deltaTime;
				}
			}
		}
	}
}
