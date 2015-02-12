using UnityEngine;
using System.Collections;

public class DelaySplash : MonoBehaviour {
	void Start () {
		StartCoroutine(WaitAndClose(1.1F));
	}

	IEnumerator WaitAndClose(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel (1);
	}
}
