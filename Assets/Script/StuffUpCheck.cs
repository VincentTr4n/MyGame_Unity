using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffUpCheck : MonoBehaviour
{
    
    // Enemy object 
	public GameObject stuffUp;
    
    // Position to generate clone stuff
	public GameObject generate;

	GameObject stuffClone;
 
	bool onTrigger;
    
    // Maximum time respawn clone 
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
            Debug.Log("Stuff Clone destroyed");
            
            // Reset values
			onTrigger = false;
			timeLife = 0f;
		}

        // Move up stuff (Clone)
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
            // Respawn clone
			stuffClone = Instantiate(stuffUp, generate.transform.position, generate.transform.rotation);
			timeLife = 0f;
			onTrigger = true;
		}
	}
}
