using UnityEngine;
using System.Collections;

public class CampoController : MonoBehaviour {

	private float velocity;

	void Start () {
		configSize ();
	}

	void configSize(){
		float factorX = ((float)Screen.width / (float)Screen.height)/0.6f;
		transform.localScale = new Vector3 (1080f*factorX, 192, 1);
	}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "endTop") {
			GameStateController.change(GameStateController.gameStates.newCampo);
			DestroyObject(gameObject);
			if(transform.parent != null)
				DestroyObject(transform.parent.gameObject);
		}
	}

	void OnEnable(){
		GameStateController.onStateChange += onStateChange;
	}
	
	void OnDisable(){
		GameStateController.onStateChange -= onStateChange;
	}
	
	void onStateChange(GameStateController.gameStates newState){}

}
