using UnityEngine;
using System.Collections;

public class ButtonSoundController : MonoBehaviour {
	public Sprite soundOn;
	public Sprite soundOff;
	private SpriteRenderer spriteRenderer; 

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (InfoController.Instance.sound){
			spriteRenderer.sprite = soundOn;
		}else{
			audio.Stop();
			spriteRenderer.sprite = soundOff;
		}
	}

	void Update () {
		if(!InfoController.Instance.isDialog){
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
				if(collider2D.OverlapPoint(mousePosition)){
					if(!InfoController.Instance.sound){
						audio.Play();
						spriteRenderer.sprite = soundOn;
						InfoController.Instance.enableSound();
					} else {
						audio.Pause();
						spriteRenderer.sprite = soundOff;
						InfoController.Instance.disableSound();
					}
				}
			}
		}
	}
}
