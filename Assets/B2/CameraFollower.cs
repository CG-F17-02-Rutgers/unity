using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform target;
    public Vector3 targetOffset;

    public float cameraDistance = 3.0f;
    public float maxY =  60.0f;
    public float minY = -60.0f;

    private float camX = 0;
    private float camY = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camX += mouseX;
        camY -= mouseY;

        camY = Mathf.Clamp(camY, minY, maxY);

        Quaternion rot = Quaternion.Euler(camY, camX, 0);
        transform.position = target.position + targetOffset;
        transform.rotation = rot;
        transform.Translate(Vector3.back * cameraDistance, Space.Self);

    }
}
