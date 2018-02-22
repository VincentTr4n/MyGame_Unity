using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public int points;
	public AudioSource source;
	public AudioClip pickSound;
	void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Control>() == null)
            return;
        Score.AddPoint(points);
        Destroy (gameObject);
		source.PlayOneShot(pickSound);
    }
}
