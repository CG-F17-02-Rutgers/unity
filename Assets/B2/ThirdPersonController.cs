using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public Transform forwardReference;
    
    private Animator animator;

    private bool running = false;

    private int speedID;
    private int turningID;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        speedID = Animator.StringToHash("Speed");
        turningID = Animator.StringToHash("Turning");
	}
	
	// Update is called once per frame
	void Update () {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        //float angle = Vector3.Angle(Vector3.ProjectOnPlane(transform.forward, Vector3.up), Vector3.ProjectOnPlane(forwardReference.forward, Vector3.up));
        //float angle = Vector3.SignedAngle(transform.forward, forwardReference.forward, Vector3.up);
        //angle = Mathf.Clamp(angle, -1, 1);
        //Debug.Log(angle);

        //angle = Mathf.Clamp(angle / 10.0f, -1, 1);
        //animator.SetFloat(turningID, angle);

        //transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(forwardReference.forward,Vector3.up));

        if (x > 0.1f) {
            animator.SetFloat(turningID, -1.0f, 0.1f, Time.deltaTime);
        } else if (x < -0.1f) {
            animator.SetFloat(turningID, 1.0f, 0.1f, Time.deltaTime);
        } else {
            animator.SetFloat(turningID, 0.0f, 0.1f, Time.deltaTime);
        }

        float moveSpeed;
        if(Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = 1.0f;
        } else {
            moveSpeed = 0.5f;
        }

        if(y > 0.1f) {
            animator.SetFloat(speedID, moveSpeed, 0.1f, Time.deltaTime);
        } else {
            animator.SetFloat(speedID, 0.0f, 0.1f, Time.deltaTime);
        }
    }
}
