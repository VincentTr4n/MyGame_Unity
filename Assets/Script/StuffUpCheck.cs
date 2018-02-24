using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffUpCheck : MonoBehaviour
{

	public GameObject stuffUp;
	public GameObject renerate;
	GameObject stuffClone;
	bool onTrigger;
	public float maxTime;
	float timeLife;


	// Use this for initialization
	void Start()
	{
		onTrigger = false;
		timeLife = 0f;
	}

	// Update is called once per frame
	void Update()
	{
		if (stuffClone != null && timeLife > maxTime)
		{
			Destroy(stuffClone);
			onTrigger = false;
			timeLife = 0f;
		}
		if (onTrigger && stuffClone != null)
		{
			stuffClone.transform.Translate(Vector3.up * 100f * Time.deltaTime);
			timeLife += Time.deltaTime;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "MainCh" && !onTrigger)
		{
			stuffClone = Instantiate(stuffUp, renerate.transform.position, renerate.transform.rotation);
			timeLife = 0f;
			onTrigger = true;
		}
	}
}
