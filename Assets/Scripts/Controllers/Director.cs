using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {
    private RaycastHit thatNigga = new RaycastHit();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo);
            if (didHit){
                if (rhInfo.collider.name.Contains("Agent")){
                    thatNigga = rhInfo;
                }
                else{
                    print("Something else is being clicked");
                }
            }
            else{
                Debug.Log("clicked on EmptySpace");
            }

        }
        if (Input.GetMouseButtonDown(1)){
            AgentController destScript = thatNigga.collider.GetComponent<AgentController>();
            if (destScript){
                destScript.Move(Input.mousePosition);
            }
        }
	}
}
