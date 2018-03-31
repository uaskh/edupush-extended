using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_sound : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;

	public void playClip(){
		audioSource = GetComponent <AudioSource> ();
		audioSource.clip = audioClip;
		audioSource.Play ();
	}

	// Use this for initialization
}
