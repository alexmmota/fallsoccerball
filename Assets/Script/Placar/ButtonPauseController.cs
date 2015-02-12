using UnityEngine;
using System.Collections;

public class ButtonPauseController : MonoBehaviour {
	public AudioClip apito;

	void Update () {
		if(!InfoController.Instance.isDialog){
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
				if(collider2D.OverlapPoint(mousePosition)){
					PlaySound.Play(audio, apito);
					InfoController.Instance.isDialog = true;
					Time.timeScale = 0;
					gameObject.AddComponent ("PausedWindow");
				}
			}
		}
	}
}
