using UnityEngine;
using System.Collections;

public class NumLifeController : MonoBehaviour {

	void Start() {
		StartCoroutine(WaitAndPrint(1F));
	}
	
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy (gameObject);
	}

}
