using UnityEngine;
using System.Collections;

public class GameModeWindow : MonoBehaviour {
	private Rect windowRect;
	public GUISkin modalGUISkin;

	private float factorX;
	private float factorY;

	private GUIContent ctAccelerometer;
	private Texture txAccelerometer;

	private GUIContent ctClose;
	private Texture txClose;

	private GUIContent ctDirectional;
	private Texture txDirectional;

	void Start () {
		modalGUISkin = (GUISkin)Resources.Load("gamemode/GUIGameMode");
		float factorY = (float)Screen.width/480f;
		
		factorX = (float)Screen.width / 480f;
		factorY = (float)Screen.height / 800f;

		txAccelerometer = (Texture)Resources.Load("gamemode/acelerometro");
		ctAccelerometer = new GUIContent();
		ctAccelerometer.image = txAccelerometer;

		txDirectional = (Texture)Resources.Load("gamemode/tap-tap");
		ctDirectional = new GUIContent();
		ctDirectional.image = txDirectional;

		txClose = (Texture)Resources.Load("gamemode/close");
		ctClose = new GUIContent();
		ctClose.image = txClose;


		float x = 400f * factorX;
		float y = 520f * factorY;
		
		windowRect = new Rect ((Screen.width/2)-(x/2), (Screen.height/2)-(y/2), 400f*factorX, 520f*factorX);

	}

	void OnGUI(){
		GUI.skin = modalGUISkin;
		windowRect = GUI.ModalWindow (0, windowRect, ModalFunction, "");
	}

	void ModalFunction(int id){
		if(GUI.Button(new Rect(25*factorX, 70*factorX, 350f*factorX, 200f*factorX), ctAccelerometer))
		{
			InfoController.Instance.gamemode=2;
			Application.LoadLevel (2);
			InfoController.Instance.isDialog = false;
			Destroy(this);
		}

		if(GUI.Button(new Rect(25*factorX, 245*factorX, 350f*factorX, 200*factorX), ctDirectional))
		{
			InfoController.Instance.gamemode=1;
			Application.LoadLevel (2);
			InfoController.Instance.isDialog = false;
			Destroy(this);
		}

		if(GUI.Button(new Rect(100*factorX, 415*factorX, 200*factorX, 90*factorX), ctClose))
		{
			InfoController.Instance.isDialog = false;
			Destroy(this);
		}
	}
}
