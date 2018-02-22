using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelM;
	public AudioSource theme;
	public AudioSource source;
	public AudioClip sound;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainCh")
        {
			theme.Stop();
			source.PlayOneShot(sound);
			levelM.Respawn();
			theme.Play();
		}
    }
}
