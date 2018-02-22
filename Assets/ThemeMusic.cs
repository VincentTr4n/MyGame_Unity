using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour {

	AudioSource source;
	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();
	}
	public void Run(AudioClip audio)
	{
		source.PlayOneShot(audio);
	}
	public void Stop()
	{
		source.Stop();
	}
	public void Play()
	{
		source.Play();
	}
}
