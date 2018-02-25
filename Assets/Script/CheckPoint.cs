using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    // 
    // Levem manager object for save current player
    public LevelManager levelM;

	// Use this for initialization
	void Start () {
        levelM = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainCh")
        {
            // Saved
            levelM.currentCP = gameObject;
            Debug.Log("Actived CheckPoint" + transform.position);
        }
    }
}
