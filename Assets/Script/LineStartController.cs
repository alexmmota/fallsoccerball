using UnityEngine;
using System.Collections;

public class LineStartController : MonoBehaviour {
	protected Animator animator;

	void Start () {

		float factorX = ((float)Screen.width / (float)Screen.height)/0.6f;
		transform.localScale = new Vector3 (transform.localScale.x*factorX, transform.localScale.y, 1);
		transform.position = new Vector3 (transform.position.x * factorX, transform.position.y, transform.position.z);
	}
}
