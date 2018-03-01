using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileChecker : MonoBehaviour {

    public GameObject missile;
    public Transform localStart;

    private MissileControl controller;
    private GameObject missileClone;

	// Use this for initialization
	void Start () {
        controller = FindObjectOfType<MissileControl>();

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && missileClone==null)
        {
            missileClone = Instantiate(missile, localStart.position, localStart.rotation);
        }
    }

}
