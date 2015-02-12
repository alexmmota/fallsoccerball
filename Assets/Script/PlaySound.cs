using UnityEngine;
using System.Collections;

public class PlaySound {

	public static void Play(AudioSource audioSource, AudioClip audioClip){
		if(InfoController.Instance.sound)
			audioSource.PlayOneShot(audioClip);
	}
}
