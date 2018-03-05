﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGenEnemy : MonoBehaviour {


    private EnemySpawner enemySpawner;
	// Use this for initialization
	void Start () {
        enemySpawner = FindObjectOfType<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainCh" && !enemySpawner.isStart)
        {
            enemySpawner.isStart = true;
            Debug.Log("Actived CheckPoint" + transform.position);
        }
    }
}
