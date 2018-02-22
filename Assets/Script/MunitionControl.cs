using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionControl : MonoBehaviour {

	public float speed;
	public Control player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int damage;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Control>();
		if (player.transform.localScale.x < 0) speed *= -1f;
	}
	
	// Update is called once per frame
	void Update () {
		var rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name!="Wall" && other.tag!="CheckPoint" && other.name != "MainCh" && other.name !="melee")
		{
			var clone = Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			DeleteClones();
		}
		if (other.tag == "Enemy")
		{
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy(other.gameObject);
			other.GetComponent<EnemyHealthManager>().GiveDamage(damage);
		}
	}
	void DeleteClones()
	{
		var clones = GameObject.FindGameObjectsWithTag("EffectClone");
		for (int i = 0; i < clones.Length-1; i++) Destroy(clones[i]);
 	}
}
