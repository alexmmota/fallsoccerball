using UnityEngine;
using System.Collections;

public class FonteController : MonoBehaviour {

	public Transform target;

	void Start () {
		float factorY = (float)Screen.width/480f;
		guiText.fontSize = (int)(factorY * guiText.fontSize);
	}

	void Update(){
		Vector3 pos = new Vector3(target.position.x + guiText.pixelOffset.x, target.position.y + guiText.pixelOffset.y, 180f);
		transform.position = Camera.main.WorldToViewportPoint (pos);
	}
}
