using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMoving : MonoBehaviour {
	public float speed = 2.0f;
	private bool dirRight;

	void Update () {
		if(transform.position.x >= -78.0f) {
			dirRight = false;
		}

		if(transform.position.x <= -120.0f){
			dirRight = true;
		}
		if (dirRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} 
		else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}
	}
}
