using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileChecker : MonoBehaviour {

    public GameObject missile;
    public Transform localStart;

    private MissileControl controller;
    private GameObject clone;

	// Use this for initialization
	void Start () {
        controller = FindObjectOfType<MissileControl>();

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && clone==null)
        {
            clone = Instantiate(missile, localStart.position, localStart.rotation);

            var player = GameObject.FindGameObjectWithTag("Player");

            // Set component for clone object 
            clone.GetComponent<KillPlayer>().levelM = FindObjectOfType<LevelManager>();
            clone.GetComponent<KillPlayer>().theme = GameObject.Find("SoundPlayer").GetComponent<AudioSource>();
            clone.GetComponent<KillPlayer>().theme = GameObject.Find("ThemeMusic").GetComponent<AudioSource>();
            clone.gameObject.GetComponent<EnemyAI>().targer = player.transform;
        }
    }

}
