using UnityEngine;
using System.Collections;

public class PausedWindow : MonoBehaviour {
	private Rect windowRect;
	public GUISkin modalGUISkin;
	
	private float factorX;
	private float factorY;
	
	public GUIStyle style;
	public Font font;
	
	private GUIContent ctContinue;
	private Texture2D txContinue;

	private GUIContent ctQuit;
	private Texture2D txQuit;

	void Start () {
		modalGUISkin = (GUISkin)Resources.Load("pause/GUIPause");

		factorX = (float)Screen.width / 480f;
		factorY = (float)Screen.height / 800f;
		
		txContinue = (Texture2D)Resources.Load("pause/continue");
		ctContinue = new GUIContent();
		ctContinue.image = txContinue;

		txQuit = (Texture2D)Resources.Load("pause/sair");
		ctQuit = new GUIContent();
		ctQuit.image = txQuit;

		float x = 330f * factorX;
		float y = 160f * factorY;
		
		windowRect = new Rect ((Screen.width/2)-(x/2), (Screen.height/2)-(y/2), 330f*factorX, 160f*factorX);

		
	}

	void OnGUI(){
		GUI.skin = modalGUISkin;
		windowRect = GUI.ModalWindow (0, windowRect, ModalFunction, "");
	}
	
	void ModalFunction(int id){
		if(GUI.Button(new Rect(24*factorX, 65*factorX, 132*factorX, 88*factorX), ctContinue))
		{
			InfoController.Instance.isDialog = false;
			Time.timeScale = 1;
			Destroy(this);
		}

		if(GUI.Button(new Rect(172*factorX, 65*factorX, 132*factorX, 88*factorX), ctQuit))
		{
			Time.timeScale = 1;
			InfoController.Instance.setDefaultValues();
			Application.LoadLevel (1);
			Destroy(this);
		}
	}
}
