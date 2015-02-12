using UnityEngine;
using System.Collections;

public class PlacarController : MonoBehaviour {
	private int score;
	private int life;

	public GUIText scoreText;
	public GUIText lifeText;

	public AudioClip fall;
	public AudioClip success;
	public AudioClip kick;
	public AudioClip soundExplosion;

	void Start () {
		setDefaultValues ();
		showText ();
	}

	void setDefaultValues(){
		score = InfoController.Instance.score;
		life = InfoController.Instance.life;
	}
	
	void OnEnable(){
		GameStateController.onStateChange += onStateChange;
	}
	
	void OnDisable(){
		GameStateController.onStateChange -= onStateChange;
	}
	
	void onStateChange(GameStateController.gameStates newState){
		switch(newState){
			case GameStateController.gameStates.getPoint:
				PlaySound.Play(audio, kick);
				incrementScore(1);
			break;
		
			case GameStateController.gameStates.getDeath:
				PlaySound.Play(audio, fall);
				decrementLife(1);
			break;

			case GameStateController.gameStates.getLife:
				PlaySound.Play(audio, success);
				incrementLife(1);
			break;

			case GameStateController.gameStates.getYellowcard:
				PlaySound.Play(audio, fall);
				decrementLife(1);
			break;
	
			case GameStateController.gameStates.getRedCard:
				PlaySound.Play(audio, fall);
				decrementLife(2);
			break;

			case GameStateController.gameStates.getThrophyBronze:
				PlaySound.Play(audio, success);
				incrementLife(1);
			break;

			case GameStateController.gameStates.getThrophySilver:
				PlaySound.Play(audio, success);
				incrementLife(2);
			break;

			case GameStateController.gameStates.getThrophyGold:
				PlaySound.Play(audio, success);
				incrementLife(10);
			break;

			case GameStateController.gameStates.getRedApito:
				//PlaySound.Play(audio, success);
				PlaySound.Play(audio, soundExplosion);
				decrementScore(10);
			break;

			case GameStateController.gameStates.getGoldApito:
				//PlaySound.Play(audio, success);
				PlaySound.Play(audio, soundExplosion);
				incrementScore(10);
			break;
		}
	}

	void incrementScore(int value){
		score += value;
		InfoController.Instance.score = score;
		showText ();
	}

	void decrementScore(int value){
		score -= value;
		if (score < 0)
			score = 0;
		InfoController.Instance.score = score;
		showText ();
	}

	void incrementLife(int value){
		life += value;
		if (life > 10)
			life = 10;
		showText ();
		InfoController.Instance.life = life;
	}

	void decrementLife(int value){
		life -= value;
		if (life < 0)
			life = 0;
		showText ();
		InfoController.Instance.life = life;
		checkKill ();
	}

	void showText(){
		lifeText.text = life.ToString("D2");
		scoreText.text = score.ToString("D4");
	}

	private void checkKill(){
		if (life < 1) {
			GameStateController.change(GameStateController.gameStates.kill);
		}
	}

}
