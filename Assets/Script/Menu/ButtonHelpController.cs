using UnityEngine;
using System.Collections;

public class ButtonHelpController : MonoBehaviour {

	void Update () {
		if(!InfoController.Instance.isDialog){
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
				if(collider2D.OverlapPoint(mousePosition)){
					InfoController.Instance.isDialog = true;
					gameObject.AddComponent ("HelpWindow");
				}
			}
		}
	}
}
