using UnityEngine;
using System.Collections;

public class AccelerometerController : MonoBehaviour {
	public bool isStart = false;
	public Transform phone;
	public Transform line;

	void Start() {
		StartCoroutine(WaitAndPrint(0.5F));
	}
	
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		isStart = true;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && isStart) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			if(collider2D.OverlapPoint(mousePosition)){
				InfoController.Instance.isStart = true;
				Destroy(gameObject);
				Destroy(phone.gameObject);
				Destroy(line.gameObject);
			}
		}
	}
}
