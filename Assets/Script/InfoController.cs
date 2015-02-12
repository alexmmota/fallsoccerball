using UnityEngine;
using System.Collections;

public class InfoController {

	public static InfoController instance;
	public float velocity;
	public int life;
	public int score;
	public float factorVelocity;
	public bool showGameOver;
	public bool isDialog;
	public bool sound;
	public int level;
	public bool isStart;
	public int gamemode;
	public bool moveLine;
	public bool moveLineRotate;
	public int posCamera;
	public Transform lastCampo;

	private InfoController(){
		setDefaultValues ();
		GameStateController.onStateChange += onStateChange;
	}


	public void setDefaultValues(){
		if(PlayerPrefs.GetInt("sound") == 1){
			sound = true;
		}else{
			sound = false;
		}

		posCamera = 1;
		moveLine = false;
		isStart = false;
		level = 1;
		isDialog = false;
		velocity = 0.04f;
		life = 10;
		score = 0;
		showGameOver = false;
	}

	public static InfoController Instance{
		get{
			if (instance == null) {
				instance = new InfoController();
			}
			return instance;
		}
	}
	
	void onStateChange(GameStateController.gameStates newState){
		switch (newState) {
		case GameStateController.gameStates.upVelocity:
			velocity += 0.005f;
			break;
			
		case GameStateController.gameStates.downVelocity:
			velocity -= 0.005f;
			break;
		case GameStateController.gameStates.getPoint:
			score++;
			break;
			
		case GameStateController.gameStates.getDeath:
			life--;
			break;
			
		case GameStateController.gameStates.getLife:
			life++;
			break;
		}
	}

	public void disableSound(){
		sound = false;
		PlayerPrefs.SetInt("sound", 0);
	}

	public void enableSound(){
		sound = true;
		PlayerPrefs.SetInt("sound", 1);
	}
}
