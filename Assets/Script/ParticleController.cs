using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	void Start () {
		Destroy(this.gameObject, 3f);
	}
	
}
