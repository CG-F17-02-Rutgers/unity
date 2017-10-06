using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {
	
	private List<GameObject> selectedAgents;

	private Collider[] movingOb = new Collider[2];
	private bool[] chosenOb = new bool[2];
	public int speed;
    // Use this for initialization
    void Start () {
		selectedAgents = new List<GameObject> ();
		//initialize movableobstacles
		movingOb [0] = GameObject.FindGameObjectWithTag ("movingOb1").GetComponent<Collider> (); chosenOb[0]=false;
		movingOb [1] = GameObject.FindGameObjectWithTag ("movingOb2").GetComponent<Collider> (); chosenOb[1] = false;
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

				if (rhInfo.collider.CompareTag("Agent")) {
					if(selectedAgents.Contains(selectedObject)) {
						// remove it from the list, change color back to white
						selectedObject.GetComponent<Renderer>().material.color = Color.white;
						selectedAgents.Remove(selectedObject);
					} else {
						selectedObject.GetComponent<Renderer>().material.color = Color.red;
						selectedAgents.Add(selectedObject);
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
				Debug.Log ("hit an object");
				// we hit an object. check if we can navigate to it
				foreach (GameObject o in selectedAgents) {
					o.GetComponent<AgentController> ().Move (rhInfo.point);
				}
			}

			/*
            for (int i =0; i<5; i++){
                if (chosenNiggas[i] == true){
                    AgentController destScript = thoseNiggas[i].GetComponent<Collider>().GetComponent<AgentController>();
                    destScript.Move(Input.mousePosition);
                }
            } */
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
