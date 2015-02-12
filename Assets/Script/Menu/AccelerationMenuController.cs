using UnityEngine;
using System.Collections;

public class AccelerationMenuController : MonoBehaviour {
	public float force;

	void Start(){
		Screen.orientation = ScreenOrientation.Portrait;
	}

	void Update(){
		Vector2 dir = Vector2.zero;
		
		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.y;

		if (dir.x > 0) {
			rigidbody2D.AddForce(dir * force);
		}
		
		if (dir.x < 0) {
			rigidbody2D.AddForce(dir * force);
		}
		
		if (dir.y > 0) {
			rigidbody2D.AddForce(dir * force);
		}
		
		if (dir.y < 0) {
			rigidbody2D.AddForce(dir * force);
		}	
	}
}