using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioClip music;

	void Start () {
		if (InfoController.Instance.sound)
			audio.PlayOneShot (music);
	}
	
}
