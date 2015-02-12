using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ButtonRankController : MonoBehaviour {

	void Update () {
		if(!InfoController.Instance.isDialog){
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
				if(collider2D.OverlapPoint(mousePosition)){
					((PlayGamesPlatform) Social.Active).ShowLeaderboardUI("CgkI2PHx5pENEAIQBg");
				}
			}
		}
	}
}
