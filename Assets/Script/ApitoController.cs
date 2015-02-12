using UnityEngine;
using System.Collections;

public class ApitoController : MonoBehaviour {
	private float velocty;
	public Transform particleGold;
	public Transform particleRed;
	public Transform mais10;
	public Transform menos10;

	void Start(){
		velocty = -0.04f * Time.deltaTime *50;
	}

	void Update () {
		transform.Translate(new Vector3(0f, velocty, 0f));
	}

	void OnEnable(){
		GameStateController.onStateChange += onStateChange;
	}
	
	void OnDisable(){
		GameStateController.onStateChange -= onStateChange;
	}
	
	void onStateChange(GameStateController.gameStates newState){}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "ball") {
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
			Vector3 posLife = new Vector3(transform.position.x+0.4f, transform.position.y+0.7f, transform.position.z);
			if(gameObject.tag == "apitobad"){
				Instantiate(particleRed, pos, transform.rotation);
				Instantiate(menos10, posLife, transform.rotation);
				GameStateController.change(GameStateController.gameStates.getRedApito);
			}else{
				Instantiate(particleGold, pos, transform.rotation);
				Instantiate(mais10, posLife, transform.rotation);
				GameStateController.change(GameStateController.gameStates.getGoldApito);
			}
			DestroyObject(gameObject);
		}else if (obj.tag == "endBottom") {
			DestroyObject(gameObject);
		}
	}

}
