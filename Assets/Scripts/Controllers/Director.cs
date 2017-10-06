using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {
    private RaycastHit thatNigga = new RaycastHit();
    private Collider [] thoseNiggas = new Collider [5];
    private bool[] chosenNiggas = new bool[5];

	private Collider[] movingOb = new Collider[2];
	private bool[] chosenOb = new bool[2];
	public int speed;
    // Use this for initialization
    void Start () {
		//initialize agent
		for (int i=0; i<5; i++){
            thoseNiggas[i] = GameObject.FindGameObjectWithTag("Agent" + i).GetComponent<Collider>();
            chosenNiggas[i] = false;
        }
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
                if (rhInfo.collider.name.Equals("Agent0")){
                    if (chosenNiggas[0] == true){
                        chosenNiggas[0] = false;
                        thoseNiggas[0].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.white;
                    }
                    else{
                        chosenNiggas[0] = true;
                        thoseNiggas[0].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                if (rhInfo.collider.name.Equals("Agent1")){
                    if (chosenNiggas[1] == true){
                        chosenNiggas[1] = false;
                        thoseNiggas[1].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.white;
                    }
                    else{
                        chosenNiggas[1] = true;
                        thoseNiggas[1].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                if (rhInfo.collider.name.Equals("Agent2")){
                     if (chosenNiggas[2] == true){
                        chosenNiggas[2] = false;
                        thoseNiggas[2].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.white;
                    }
                    else{
                        chosenNiggas[2] = true;
                        thoseNiggas[2].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                if (rhInfo.collider.name.Equals("Agent3")){
                    if (chosenNiggas[3] == true){
                        chosenNiggas[3] = false;
                        thoseNiggas[3].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.white;
                    }
                    else{
                        chosenNiggas[3] = true;
                        thoseNiggas[3].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                if (rhInfo.collider.name.Equals("Agent4")){
                    if (chosenNiggas[4] == true){
                        chosenNiggas[4] = false;
                        thoseNiggas[4].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.white;
                    }
                    else{
                        chosenNiggas[4] = true;
                        thoseNiggas[4].GetComponent<Rigidbody>().GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                //Debug.Log(chosenNiggas[0] + "," + chosenNiggas[1] + "," + chosenNiggas[2] + "," + chosenNiggas[3] + "," + chosenNiggas[4]);
            }
            else{
                //Debug.Log("clicked on EmptySpace");
            }

        }
        if (Input.GetMouseButtonDown(1)){
			//Debug.Log (Input.mousePosition);
            for (int i =0; i<5; i++){
                if (chosenNiggas[i] == true){
                    AgentController destScript = thoseNiggas[i].GetComponent<Collider>().GetComponent<AgentController>();
                    destScript.Move(Input.mousePosition);
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
