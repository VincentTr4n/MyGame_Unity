using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

	public LevelManager levelM;
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
			levelM.Respawn();
			liftManager.TakeLife();
			if (liftManager.LifeCounter <= 0)
			{
				liftManager.GameOverSound.Play();
				pause.ShowScreenGO();
			}
			else
			{
				source.PlayOneShot(sound);
				theme.Play();
			}
		}
	}
}
