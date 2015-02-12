using UnityEngine;
using System.Collections;

public class ButtonQuitController : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		if(!InfoController.Instance.isDialog){
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
				if(collider2D.OverlapPoint(mousePosition)){
					Debug.Log("Quit");
					Application.Quit();
				}
			}
		}
	}
}
