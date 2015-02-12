using UnityEngine;
using System.Collections;

public class HelpWindow : MonoBehaviour {
	private Rect windowRect;
	public GUISkin modalGUISkin;

	private float factorX;
	private float factorY;

	public GUIStyle style;
	public GUIStyle style2;
	public Font font;

	private GUIContent ctClose;
	private Texture txClose;

	private string textItens;
	private string textYellowCard;
	private string textRedCard;
	private string textThrophyBronze;
	private string textThrophySilver;
	private string textThrophyGold;


	void Start () {
		Debug.Log (Application.systemLanguage);
		if (Application.systemLanguage.ToString().Equals("Portuguese")) {
			textItens = "Itens";
			textYellowCard = "Perca uma vida ao pegar \neste item";
			textRedCard = "Perca duas vidas ao pegar \neste item";
			textThrophyBronze = "Ganhe uma vida ao pegar \neste item";
			textThrophySilver = "Ganhe duas vidas ao pegar \neste item";
			textThrophyGold = "Restaure todas as vidas ao \npegar este item";
		} else {
			textItens = "Items";
			textYellowCard = "Lose one life when get \nthis item";
			textRedCard = "Lose two lives when get \nthis item";
			textThrophyBronze = "Win one life if get \nthis item";
			textThrophySilver = "Win two lives if get \nthis item";
			textThrophyGold = "Restore all lives if get \nthis item";
		}

		modalGUISkin = (GUISkin)Resources.Load("help/GUIHelp");
		float factorY = (float)Screen.width/480f;
		
		font = (Font)Resources.Load("ArialRoundedMTBold");
		
		style = new GUIStyle ();
		style.fontSize = (int)(factorY * 27f);
		style.font = font;
		style.normal.textColor = new Color (29f/255f, 165f/255f, 29f/255f);

		style2 = new GUIStyle ();
		style2.fontSize = (int)(factorY * 21f);
		style2.font = font;
		style2.normal.textColor = new Color (29f/255f, 165f/255f, 29f/255f);

		factorX = (float)Screen.width / 480f;
		factorY = (float)Screen.height / 800f;

		txClose = (Texture)Resources.Load("help/close");
		ctClose = new GUIContent();
		ctClose.image = txClose;


		float x = 400f * factorX;
		float y = 600f * factorY;
		
		windowRect = new Rect ((Screen.width/2)-(x/2), (Screen.height/2)-(y/2), 400f*factorX, 600f*factorX);

	}

	void OnGUI(){
		GUI.skin = modalGUISkin;
		windowRect = GUI.ModalWindow (0, windowRect, ModalFunction, "");
	}

	void ModalFunction(int id){
		GUI.Label(new Rect(40*factorX, 100*factorX, 50*factorX, 30*factorX), textItens, style);
		GUI.Label(new Rect(100*factorX, 160*factorX, 50*factorX, 30*factorX), textRedCard, style2);
		GUI.Label(new Rect(100*factorX, 235*factorX, 50*factorX, 30*factorX), textYellowCard, style2);
		GUI.Label(new Rect(100*factorX, 310*factorX, 50*factorX, 30*factorX), textThrophyBronze, style2);
		GUI.Label(new Rect(100*factorX, 380*factorX, 50*factorX, 30*factorX), textThrophySilver, style2);
		GUI.Label(new Rect(100*factorX, 450*factorX, 50*factorX, 30*factorX), textThrophyGold, style2);

		if(GUI.Button(new Rect(100*factorX, 500*factorX, 200*factorX, 90*factorX), ctClose))
		{
			InfoController.Instance.isDialog = false;
			Destroy(this);
		}
	}
}
