using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class FinalWindow : MonoBehaviour {

	private Rect windowRect;
	public GUISkin modalGUISkin;

	private float factorX;
	private float factorY;

	private Texture txHome;
	private Texture txRestart;
	private Texture txLike;
	private Texture txRank;

	public GUIText score;
	public GUIText highscore;

	public GUIStyle style;
	public Font font;

	private GUIContent ctHome;
	private GUIContent ctRestart;
	private GUIContent ctLike;
	private GUIContent ctRank;
	
	void Start(){
		modalGUISkin = (GUISkin)Resources.Load("gameover/ModalGUI");
		float factorY = (float)Screen.width/480f;

		font = (Font)Resources.Load("ArialRoundedMTBold");

		style = new GUIStyle ();
		style.fontSize = (int)(factorY * 23f);
		style.font = font;
		style.normal.textColor = new Color (29f/255f, 165f/255f, 29f/255f);

		txHome = (Texture)Resources.Load("gameover/home");
		txRestart = (Texture)Resources.Load ("gameover/restart");
		txLike = (Texture)Resources.Load ("gameover/like");
		txRank = (Texture)Resources.Load ("gameover/rank");

		ctHome = new GUIContent();
		ctHome.image = txHome;

		ctRestart = new GUIContent();
		ctRestart.image = txRestart;

		ctLike = new GUIContent();
		ctLike.image = txLike;

		ctRank = new GUIContent();
		ctRank.image = txRank;

		factorX = (float)Screen.width / 480f;
		factorY = (float)Screen.height / 800f;

		float x = 400f * factorX;
		float y = 245f * factorY;

		windowRect = new Rect ((Screen.width/2)-(x/2), (Screen.height/2)-(y/2), 400f*factorX, 245f*factorX);
	}
	
	void OnGUI(){
		if (InfoController.Instance.showGameOver) {
			GUI.skin = modalGUISkin;
			windowRect = GUI.ModalWindow (0, windowRect, ModalFunction, "");
		}
	}

	void ModalFunction(int id){
		int highscore = InfoController.Instance.score;
		int score = InfoController.Instance.score;

		if(PlayerPrefs.GetInt("savedScore") > highscore){
			highscore = PlayerPrefs.GetInt("savedScore");
		}else{
			PlayerPrefs.SetInt("savedScore", score);
		}

		Social.ReportScore(highscore, "CgkI2PHx5pENEAIQBg", (bool success) => {
			Debug.Log("saved score");
		});

		GUI.Label(new Rect(180*factorX, 83*factorX, 100*factorX, 30*factorX), highscore.ToString(), style);
		GUI.Label(new Rect(180*factorX, 120*factorX, 100*factorX, 30*factorX), score.ToString(), style);

		//Home
		if(GUI.Button(new Rect(45*factorX, 160*factorX, 66*factorX, 66*factorX), ctHome))
		{
			InfoController.Instance.setDefaultValues();
			Application.LoadLevel (1);
			Destroy(this);
		}

		//Facebook
		if(GUI.Button(new Rect(110*factorX, 160*factorX, 80*factorX, 55*factorX), ctLike))
		{
			FacebookController face = new FacebookController();
			face.ShareToFacebook(score);
		}

		//Rank
		if(GUI.Button(new Rect(190*factorX, 160*factorX, 100*factorX, 55*factorX), ctRank))
		{
			((PlayGamesPlatform) Social.Active).ShowLeaderboardUI("CgkI2PHx5pENEAIQBg");
		}

		//Restart
		if(GUI.Button(new Rect(300*factorX, 160*factorX, 65*factorX, 55*factorX), ctRestart))
		{
			InfoController.Instance.setDefaultValues();
			Application.LoadLevel (2);
		}

	}
}
