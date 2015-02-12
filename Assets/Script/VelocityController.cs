using UnityEngine;
using System.Collections;

public class VelocityController : MonoBehaviour {

	private float velocity;

	void Start () {
		velocity = InfoController.Instance.velocity;
	}

	void Update () {
		if(InfoController.Instance.isStart)
			transform.Translate(new Vector3(0f, velocity * Time.deltaTime * 50, 0f));
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
			velocity += 0.005f;
			break;
			
		case GameStateController.gameStates.downVelocity:
			velocity -= 0.005f;
			break;
		}
	}
}
