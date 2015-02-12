using UnityEngine;
using System.Collections;

public class GameStateListener : MonoBehaviour {
	public Transform inicioRaycastTop;
	public Transform fimRaycastTop;
	public Transform inicioRaycastBotton;
	public Transform fimRaycastBotton;
	public Transform ball;
	public AudioClip apito;
	public AudioClip soundBall;
	public Transform pApitoGood;
	public Transform pApitoBad;
	private System.Random random;

	public PhysicsMaterial2D matBall1;
	public PhysicsMaterial2D matBall2;
	public Sprite soccerBall;
	public Sprite basketBall;
	private SpriteRenderer spriteRenderer;

	private int beforeSurprise;

	private int life;

	int rndAnt=0;
	public Transform[] campos;

	void Start(){
		setDefaultValues ();
	}
	
	void Update () {
		checkDeath ();
	}

	void setDefaultValues(){
		spriteRenderer = ball.GetComponent<SpriteRenderer>();
		random = new System.Random ();
		life = InfoController.Instance.life;
		gameObject.AddComponent ("FinalWindow");
	}

	void checkDeath(){
		Debug.DrawLine (inicioRaycastBotton.position, fimRaycastBotton.position, Color.red);
		Debug.DrawLine (inicioRaycastTop.position, fimRaycastTop.position, Color.red);
		if ((Physics2D.Linecast (inicioRaycastTop.position, fimRaycastTop.position, 1 << LayerMask.NameToLayer ("ball")))
		    || (Physics2D.Linecast (inicioRaycastBotton.position, fimRaycastBotton.position, 1 << LayerMask.NameToLayer ("ball")))) {
			GameStateController.change(GameStateController.gameStates.getDeath);
		}
	}

	void OnEnable(){
		GameStateController.onStateChange += onStateChange;
	}

	void OnDisable(){
		GameStateController.onStateChange -= onStateChange;
	}

	void onStateChange(GameStateController.gameStates newState){
		switch (newState) {
			case GameStateController.gameStates.getDeath:
				death();
			break;
		
			case GameStateController.gameStates.kill:
				kill();
			break;
		
			case GameStateController.gameStates.getPoint:
				getPoint();
			break;

			case GameStateController.gameStates.getSurprise:
				getSurprise();
			break;

			case GameStateController.gameStates.newCampo:
				Instantiate (generatedCampo (), new Vector3 (0f, InfoController.Instance.lastCampo.position.y-3.84f, 0f), Quaternion.identity);
			break;
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

	void getSurprise(){
		int surprise = random.Next (0, 6);

		if(surprise == beforeSurprise){
			if(surprise == 5)
				surprise-=1;
			else
				surprise+=1;
		}
		beforeSurprise = surprise;

		switch(surprise){
		case 0:
			InfoController.Instance.moveLine = true;
			StartCoroutine(WaitAndStopLine(6F));
			break;
		case 1:
			ball.animation.Play ("ballIncreaseAnimation");
			PlaySound.Play(audio, soundBall);
			StartCoroutine(WaitAndRestoreBall(10F));
			break;
		case 2:
			Camera.main.animation.Play ("invertCameraAnimation");
			InfoController.Instance.posCamera = -1;
			StartCoroutine(WaitAndRevertCamera(10F));
			break;
		case 3:
			InfoController.Instance.moveLine = true;
			InfoController.Instance.moveLineRotate = true;
			StartCoroutine(WaitAndStopLine(6F));
			break;
		case 4:
			for(int i=0; i < 2; i++){
				Instantiate (getApito(), new Vector3 (0f, 7f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (-4f, 7.2f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (4f, 6.8f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (2f, 11f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (-2.1f, 10.7f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (-4f, 13.5f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (-2f, 14f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (4.1f, 13.9f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (0f, 16f+(i*13), 0f), Quaternion.identity);
				Instantiate (getApito(), new Vector3 (2f, 15.6f+(i*13), 0f), Quaternion.identity);
			}
			break;
		case 5:
			ball.collider2D.sharedMaterial = matBall2;
			spriteRenderer.sprite = basketBall;
			ball.collider2D.enabled = false;
			ball.collider2D.enabled = true;
			StartCoroutine(WaitAndRevertMatBall(10F));
			break;
		}
	}

	private Transform getApito(){
		if (random.Next (0, 2) == 0)
			return pApitoGood;
		else
			return pApitoBad;
	}

	void death(){
		if (life == 0) {
			GameStateController.change(GameStateController.gameStates.kill);
		} else {
			ball.transform.position = new Vector3 (0f, 0f, 1f);
			ball.rigidbody2D.AddForce(Vector2.zero);
		}
	}

	IEnumerator WaitAndStopLine(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		InfoController.Instance.moveLine = false;
		InfoController.Instance.moveLineRotate = false;
	}

	IEnumerator WaitAndRestoreBall(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		ball.animation.Play ("ballDecreaseAnimation");
	}

	IEnumerator WaitAndRevertCamera(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Camera.main.animation.Play ("revertCameraAnimation");
		InfoController.Instance.posCamera = 1;
	}

	IEnumerator WaitAndRevertMatBall(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		spriteRenderer.sprite = soccerBall;
		ball.collider2D.sharedMaterial = matBall1;
		ball.collider2D.enabled = false;
		ball.collider2D.enabled = true;
	}

	void kill(){
		PlaySound.Play(audio, apito);
		Destroy(ball.gameObject);
		InfoController.Instance.isDialog = true;
		InfoController.Instance.showGameOver = true;
	}

	void getPoint(){
		if (InfoController.Instance.score % 15 == 0) {
			InfoController.Instance.level+=1;
			if(InfoController.Instance.level < 17)
				GameStateController.change(GameStateController.gameStates.upVelocity);
		}
	}
}
