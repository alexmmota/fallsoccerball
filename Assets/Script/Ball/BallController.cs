using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public float force;

	void Start(){
		force = 350f;
	}

	void Update () {
		ApplyForce ();
	}

	void ApplyForce(){
		Vector2 dir = Vector2.zero;
		dir.x = Input.GetAxis ("Horizontal") * Time.deltaTime;
		dir.y = 0;
		rigidbody2D.AddForce(dir * force);
		rigidbody2D.angularVelocity = rigidbody2D.velocity.x*-120;
	}
	
	void OnEnable(){
		GameStateController.onStateChange += onStateChange;
	}
	
	void OnDisable(){
		GameStateController.onStateChange -= onStateChange;
	}
	
	void onStateChange(GameStateController.gameStates newState){
		switch (newState) {
		case GameStateController.gameStates.upVelocity:
			force += 30;
			break;
			
		case GameStateController.gameStates.downVelocity:
			force -= 30;
			break;
		}
	}
}
