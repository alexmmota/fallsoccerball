using UnityEngine;
using System.Collections;

public class AccelerationControll : MonoBehaviour {

	public float force=65f;

	void Start(){
		Screen.orientation = ScreenOrientation.Portrait;
	}

	void Update(){
		if(InfoController.Instance.gamemode == 2 && InfoController.Instance.isStart){
			Vector2 dir = Vector2.zero;
			dir.x = Input.acceleration.x;
			dir.y = Input.acceleration.y;
			rigidbody2D.AddForce(dir * force * Time.deltaTime * 12f * InfoController.Instance.posCamera);
		}
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
			force += force/10;
			break;
			
		case GameStateController.gameStates.downVelocity:
			force -= force/10;
			break;
		}
	}
}