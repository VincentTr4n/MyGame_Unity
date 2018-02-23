using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

	public int startLife;
	private int lifeCounter;
	private Text txt;

	// Use this for initialization
	void Start()
	{
		txt = GetComponent<Text>();

		lifeCounter = startLife;
	}

	// Update is called once per frame
	void Update()
	{
		if (lifeCounter >= 0) txt.text = " x " + lifeCounter;
	}
	public AudioSource GameOverSound { get { return GetComponent<AudioSource>(); } }
	public int LifeCounter { get { return lifeCounter; } }
	public void GiveLife()
	{
		lifeCounter++;
	}
	public void TakeLife()
	{
		lifeCounter--;
	}
}
