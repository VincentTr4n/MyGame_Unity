using System.Collections;
using System.Linq;
using UnityEngine;

public class MunitionControl : MonoBehaviour {

	public float speed;
	public Control player;
    
    // Death effect for destroy enemy
	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

    // Damage given to take 
	public int damage;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Control>();

        // Redirect munition
		if (player.transform.localScale.x < 0) speed *= -1f;
	}
	
	// Update is called once per frame
	void Update () {

		var rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name != "Wall" && other.tag != "CheckPoint" && other.name != "MainCh" && other.name != "melee")
		{
			var clone = Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			DeleteClones();
		}
		if (other.tag == "Enemy" || other.tag== "FlyEnemy")
		{
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy(other.gameObject);
			other.GetComponent<EnemyHealthManager>().GiveDamage(damage);
		}
	}

    // Delete clone effect 
	void DeleteClones()
	{
		var clones = GameObject.FindGameObjectsWithTag("EffectClone");
		for (int i = 0; i < clones.Length-1; i++) Destroy(clones[i]);
 	}
}
