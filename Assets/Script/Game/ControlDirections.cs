using UnityEngine;
using System.Collections;

public class ControlDirections : MonoBehaviour {
	public float force=40f;
	public Transform ball;
	public Transform arrowLeft;
	public Transform arrowRight;
	public Transform line;
	public Transform backPhone;
	public Transform phone;
	public AudioClip apito;
	public bool isStart = false;

	void Start() {
		if(InfoController.Instance.gamemode == 2){
			Destroy(arrowLeft.gameObject);
			Destroy(arrowRight.gameObject);
		}else{
			Destroy(backPhone.gameObject);
			Destroy(phone.gameObject);
			StartCoroutine(WaitAndPrint(0.5F));
		}
	}

	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		isStart = true;
	}

	void Update () {
		if(InfoController.Instance.gamemode == 1 && isStart){
			if (ball != null) {
				if (Input.touchCount > 0) {
					if (Input.GetTouch (0).position.x < Screen.width / 2) {
						MoveBall (true);
					} else {
						MoveBall (false);
					}
					if(!InfoController.Instance.isStart){
						PlaySound.Play(audio, apito);
						Destroy(arrowLeft.gameObject);
						Destroy(arrowRight.gameObject);
						Destroy(line.gameObject);
						InfoController.Instance.isStart = true;
					}
				}
			}
		}else{
			if(!isStart && InfoController.Instance.isStart){
				PlaySound.Play(audio, apito);
				isStart = true;
			}
		}
	}

	void MoveBall(bool isLeft){
		Vector2 dir = Vector2.zero;
		dir.y = 0;
		if(isLeft)
			dir.x = -12 * Time.deltaTime * InfoController.Instance.posCamera;
		else
			dir.x = 12 * Time.deltaTime * InfoController.Instance.posCamera;

		ball.rigidbody2D.AddForce(dir * force);
		ball.rigidbody2D.angularVelocity = ball.rigidbody2D.velocity.x*-150;
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
