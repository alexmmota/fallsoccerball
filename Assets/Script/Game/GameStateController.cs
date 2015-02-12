using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	public enum gameStates
	{
		normal,
		kill,
		getLife,
		getPoint,
		getDeath,
		getRedCard,
		getYellowcard,
		getGoldApito,
		getRedApito,
		getThrophyBronze,
		getThrophySilver,
		getThrophyGold,
		upVelocity,
		getSurprise,
		downVelocity,
		newCampo
	}

	public delegate void gameStateHandler(GameStateController.gameStates newState);
	public static event gameStateHandler onStateChange;

	public static void change(GameStateController.gameStates newState) {
		if (!Object.ReferenceEquals(null, onStateChange)) 
			onStateChange(newState); 
	}
}

