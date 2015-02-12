using UnityEngine;
using System.Collections;

public class FacebookController {
	int score;

	public void ShareToFacebook (int score)
	{
		this.score = score;
		FB.Init(CallFBLogin, OnHideUnity);
	}

	private void OnInitComplete()
	{
		Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
	}
	
	private void OnHideUnity(bool isGameShown)
	{
		Debug.Log("Is game showing? " + isGameShown);
	}
	
	private void CallFBLogin()
	{
		FB.Login("publish_actions", Publish);
	}
	
	
	private void Publish(FBResult result){
		FB.API ("me?fields=name", Facebook.HttpMethod.GET, UserCallBack);
	}
	
	void UserCallBack(FBResult result){
		IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.Text) as IDictionary;
		string fbname = dict["name"].ToString();
		
		Debug.Log ("Useeeer: " + fbname);
		string name = fbname + " marcou "+score+" pontos em Fall Soccer Ball";
		
		System.Collections.Generic.Dictionary<string, string> scoreData = new System.Collections.Generic.Dictionary<string, string>();
		scoreData.Add ("name", name);
		scoreData.Add ("caption", "BAIXE NA GOOGLE PLAY");
		scoreData.Add ("description", "Conduza a bola sem sofrer penalidades e ganhe pontos.");
		scoreData.Add ("picture", "https://raw.githubusercontent.com/alexmmota/fallsoccerball/master/icon.png");
		scoreData.Add ("actions", "{'name': 'Get', 'link' : 'https://play.google.com/store/apps/details?id=br.com.fallScoccerBall'}");
		
		
		FB.API ("/me/feed", Facebook.HttpMethod.POST, delegate(FBResult r) {
			Debug.Log ("Result: " + r.Text);
		}, scoreData);
	}
	
	void LogCallback(FBResult response) {
		Debug.Log(response.Text);
	}
}
