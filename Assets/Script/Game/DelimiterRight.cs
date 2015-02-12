using UnityEngine;
using System.Collections;

public class DelimiterRight : MonoBehaviour {

	void Start () {
		float factorX = ((float)Screen.width / (float)Screen.height)/0.6f;
		float factorY = ((float)Screen.height / (float)Screen.width)/1.667f;
		
		transform.position = new Vector3(5.46f * factorX, transform.position.y, transform.position.z);
		transform.localScale = new Vector3 (transform.localScale.x, 19f * factorY, 1);
	}
}
