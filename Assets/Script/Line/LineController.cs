using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {
	private bool isCount = false;
	private float velocity;
	public Transform redCard;
	public Transform yelowCard;
	public Transform throphyBronze;
	public Transform throphySilver;
	public Transform throphyGold;
	public Transform surprise;
	private float factorX;
	private bool isFeature;
	private float loops;

	private string[] animations = new string[2];

	void Start () {
		int counter = 0;
		foreach (AnimationState states in animation) {
			animations[counter++] = states.name;
		}

		isFeature = true;
		animation.enabled = false;

		setDefaultValues ();
		configSize ();
		configFeature ();
	}

	void Update(){
		if (InfoController.Instance.moveLine && !animation.enabled && !isFeature) {
			animation.enabled = true;
			if(InfoController.Instance.moveLineRotate){
				for(int i=0; i < 5; i++){
					animation.PlayQueued(animations[1]);
				}
			}else{
				for(int i=0; i < 5; i++){
					animation.PlayQueued(animations[0]);
				}
			}
		}

	}

	void setDefaultValues(){
		throphyBronze = ((GameObject)Resources.Load("throphy_bronze")).transform;
		throphySilver = ((GameObject)Resources.Load("trophy_silver")).transform;
		throphyGold = ((GameObject)Resources.Load("trophy_gold")).transform;
		yelowCard = ((GameObject)Resources.Load("yellow_card")).transform;
		redCard = ((GameObject)Resources.Load("red_card")).transform;
		surprise = ((GameObject)Resources.Load("surprise")).transform;

		factorX = ((float)Screen.width / (float)Screen.height)/0.6f;
		isCount = true;
	}

	void configSize(){
		transform.localScale = new Vector3 (180f*factorX, 25, 1);
		transform.position = new Vector3 (transform.position.x * factorX, transform.position.y, transform.position.z);
	}

	void OnCollisionEnter2D (Collision2D obj){
		if (isCount) {
			if (obj.gameObject.tag == "ball"){
				GameStateController.change (GameStateController.gameStates.getPoint);
				isCount = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "endTop") {
			DestroyObject(gameObject);
		}
	}

	void configFeature(){
		FeatureController.Feature feature = FeatureController.Instance.chooseFeature ();
		switch (feature) {
		case FeatureController.Feature.life1:
			Instantiate(throphyBronze, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
			break;
		case FeatureController.Feature.life2:
			Instantiate(throphySilver, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
			break;
		case FeatureController.Feature.life3:
			Instantiate(throphyGold, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
			break;
		case FeatureController.Feature.death1:
			Instantiate(yelowCard, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
			break;
		case FeatureController.Feature.death2:
			Instantiate(redCard, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
			break;
		case FeatureController.Feature.surprise:
			Instantiate(surprise, new Vector3(transform.position.x, transform.position.y+0.1f, 0f), Quaternion.identity);
			break;
		default:
			isFeature = false;
			break;
		}
	}
}
