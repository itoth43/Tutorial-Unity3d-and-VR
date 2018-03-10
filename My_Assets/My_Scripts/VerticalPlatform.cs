using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {

	public float speed;
	public float height;
	public float offset;

    void FixedUpdate() {
		 transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*speed, height) + offset, transform.position.z);
     }
}
