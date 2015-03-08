using UnityEngine;
using System.Collections;

public class menuship : MonoBehaviour {
	
	public float speed;
	void FixedUpdate () {
		if (transform.position.y <= 0.5f)
			rigidbody.AddForce (0, speed, 0);
		if (transform.position.y >= 0.7f)
			rigidbody.AddForce (0, -speed, 0);
	}
}
