﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

	public LevelManager levelM;

    // Play audio 
	public AudioSource theme;
	public AudioSource source;
	public AudioClip sound;

	private LifeManager liftManager;
	private PauseMenu pause;

	// Use this for initialization
	void Start()
	{
		liftManager = FindObjectOfType<LifeManager>();
		pause = FindObjectOfType<PauseMenu>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "MainCh")
		{
			theme.Stop();

            // Respawn player if ontrigger event called
			levelM.Respawn();

			liftManager.TakeLife();

            // game over when lift count <= 0
			if (liftManager.LifeCounter <= 0)
			{
				liftManager.GameOverSound.Play();
				pause.ShowScreenGO();
				Time.timeScale = 0f;
			}
			else
			{
				source.PlayOneShot(sound);
				theme.Play();
			}
		}
	}
}
