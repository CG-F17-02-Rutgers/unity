using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSStyleCamera : MonoBehaviour {

    public float cameraSpeed = 0.5f;

	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * cameraSpeed;
        float y = Input.GetAxis("Vertical") * cameraSpeed;

        transform.Translate(x, 0, y, Space.World);
	}
}
