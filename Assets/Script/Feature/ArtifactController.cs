using UnityEngine;
using System.Collections;

public class ArtifactController : MonoBehaviour {

	public Transform particleGold;
	public Transform particleSilver;
	public Transform particleBronze;
	public Transform particleRed;
	public Transform particleYellow;
	public Transform particleBlue;

	public Transform mais1;
	public Transform mais2;
	public Transform mais3;
	public Transform mais4;
	public Transform mais5;
	public Transform mais6;
	public Transform mais7;
	public Transform mais8;
	public Transform mais9;
	public Transform menos1;
	public Transform menos2;


	void OnEnable(){
		GameStateController.onStateChange += onStateChange;
	}
	
	void OnDisable(){
		GameStateController.onStateChange -= onStateChange;
	}
	
	void onStateChange(GameStateController.gameStates newState){}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "endTop") {
			DestroyObject(gameObject);
		}else if (obj.tag == "ball") {
			managerObject();
			DestroyObject(gameObject);
		}
	}

	private void managerObject(){
		Vector3 posLife = new Vector3(transform.position.x+0.4f, transform.position.y+0.7f, transform.position.z);
		if(gameObject.tag == "redCard"){
			GameStateController.change(GameStateController.gameStates.getRedCard);
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Instantiate(particleRed, pos, transform.rotation);
			Instantiate(menos2, posLife, transform.rotation);
		} else if(gameObject.tag == "yellowCard"){
			GameStateController.change(GameStateController.gameStates.getYellowcard);
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Instantiate(particleYellow, pos, transform.rotation);
			Instantiate(menos1, posLife, transform.rotation);
		} else if(gameObject.tag == "bronze"){
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Instantiate(particleBronze, pos, transform.rotation);
			if(InfoController.Instance.life < 10)
				Instantiate(mais1, posLife, transform.rotation);
			GameStateController.change(GameStateController.gameStates.getThrophyBronze);
		} else if(gameObject.tag == "silver"){
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Instantiate(particleSilver, pos, transform.rotation);
			if(InfoController.Instance.life < 10){
				if(InfoController.Instance.life < 9)
					Instantiate(mais2, posLife, transform.rotation);
				else
					Instantiate(mais1, posLife, transform.rotation);
			}
			GameStateController.change(GameStateController.gameStates.getThrophySilver);
		} else if(gameObject.tag == "surprise"){
			GameStateController.change(GameStateController.gameStates.getSurprise);
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Instantiate(particleBlue, pos, transform.rotation);
		} if(gameObject.tag == "gold"){
			Transform nLife = null;
			switch(10 - InfoController.Instance.life){
				case 1:
					nLife = mais1;
					break;
				case 2:
					nLife = mais2;
					break;
				case 3:
					nLife = mais3;
					break;
				case 4:
					nLife = mais4;
					break;
				case 5:
					nLife = mais5;
					break;
				case 6:
					nLife = mais6;
					break;
				case 7:
					nLife = mais7;
					break;
				case 8:
					nLife = mais8;
					break;
				case 9:
					nLife = mais9;
					break;
				default :
					break;
			}
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Instantiate(particleGold, pos, transform.rotation);
			if(nLife != null)
				Instantiate(nLife, posLife, transform.rotation);
			GameStateController.change(GameStateController.gameStates.getThrophyGold);
		}
	}

}
