using UnityEngine;
using System.Collections;

public class GamePlayController : MonoBehaviour {
	public Transform inicioRaycastLine;
	public Transform fimRaycastLine;
	public Transform[] campos;
	public Transform campo;
	private System.Random random;
	private bool flDrawCampo = true;
	private bool flDrawLine = true;
	int rndAnt=0;


	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		random = new System.Random ();
		generatedInitialCampo ();
	}

	private void generatedInitialCampo(){
		float posY = 0.284f;
		for (int i=0; i<3; i++) {
			Instantiate(generatedCampo(), new Vector3(0f, posY, 0f), Quaternion.identity);
			posY -= 3.84f;
		}

		float posY2 = 3.48f;
		for (int i=0; i<2; i++) {
			Instantiate(campo, new Vector3(0f, posY2, 0f), Quaternion.identity);
			posY2 += 3.84f;
		}

	}

	void Raycast(){
		Debug.DrawLine (inicioRaycastLine.position, fimRaycastLine.position, Color.red);
		if (Physics2D.Linecast (inicioRaycastLine.position, fimRaycastLine.position, 1 << LayerMask.NameToLayer ("line"))) {
			if(flDrawLine){
				if (flDrawCampo) {
					Instantiate (generatedCampo (), new Vector3 (0f, -11.236f, 0f), Quaternion.identity);
					flDrawCampo = false;
				}else{
					flDrawCampo = true;
				}
			}
			flDrawLine = false;
		} else {
			flDrawLine = true;
		}
	}

	private Transform generatedCampo(){
		int rndAtual = random.Next (0, 9);
		if ((rndAtual == 8 || rndAtual == 9) && (rndAnt == 0 || rndAnt == 5))
			rndAtual -= 3;
		else if((rndAtual == 6 || rndAtual == 7)&&(rndAnt == 1 || rndAnt == 2))
			rndAtual -= 2;
		else if((rndAtual == 4 || rndAtual == 5)&&(rndAnt == 3 || rndAnt == 9))
			rndAtual += 3;
		else if((rndAtual == 2 || rndAtual == 3)&&(rndAnt == 5 || rndAnt == 6))
			rndAtual += 3;
		else if((rndAtual == 0 || rndAtual == 1)&&(rndAnt == 7 || rndAnt == 8))
			rndAtual += 3;

		rndAnt = rndAtual;
		return campos [rndAtual];
	}


}
