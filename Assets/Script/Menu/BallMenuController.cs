using UnityEngine;
using System.Collections;

public class BallMenuController : MonoBehaviour {

	void Update () {
		//Debug.Log ("X: " + Input.acceleration.x + " Y: " + Input.acceleration.y);
		if((Input.acceleration.x >= -0.6f)&&(Input.acceleration.x <= 0.6f)&&(Input.acceleration.y < 0))
			rigidbody2D.angularVelocity = rigidbody2D.velocity.x*-8;
		if((Input.acceleration.x > -0.6f)&&(Input.acceleration.x <= 0.6f)&&(Input.acceleration.y > 0))
			rigidbody2D.angularVelocity = rigidbody2D.velocity.x*8;
	}

}
