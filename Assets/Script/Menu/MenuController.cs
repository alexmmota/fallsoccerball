using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuController : MonoBehaviour {

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		configSize ();
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => {
			Debug.Log("success");
		});
	}
	
	void configSize(){
		float factorX = ((float)Screen.width / (float)Screen.height)/0.5625f;
		transform.localScale = new Vector3 (transform.localScale.x*factorX, transform.localScale.y*factorX, 1);
	}
}
