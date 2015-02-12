using UnityEngine;
using System.Collections;

public class PrefCampoController : MonoBehaviour {
	void Start () {
		InfoController.Instance.lastCampo = transform;
	}
}
