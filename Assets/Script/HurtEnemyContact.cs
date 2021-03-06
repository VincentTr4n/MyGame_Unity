﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyContact : MonoBehaviour {

	public int damage;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" || other.tag == "FlyEnemy")
		{
            // Hurt enemy with given damage
			other.GetComponent<EnemyHealthManager>().GiveDamage(damage);
			var rb = player.GetComponent<Rigidbody2D>();
			var ct = player.GetComponent<Control>();

            // Player will knockback to left or right depends on position of player
			ct.knockBackCount = ct.knockBackLength;
			ct.knockBackRight = rb.transform.position.x < transform.position.x;
	
		}
	}
}
