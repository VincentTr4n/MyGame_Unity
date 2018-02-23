using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
	private bool facing = true;
	public float moveSpeed;
	public bool moveRight;

	bool hittingWall = false;
	public Transform wallCheck;
	float wallRadius = 0.2f;
	public LayerMask WhatIsWall;

	public bool onlyMoveLeft;


	private Animator ani;
	// Use this for initialization
	void Start()
	{
		GetComponent<Rigidbody2D>().freezeRotation = true;
		ani = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallRadius, WhatIsWall);
		if (hittingWall) moveRight = !moveRight;

		var rigidbody2D = GetComponent<Rigidbody2D>();
		if (moveRight && !onlyMoveLeft)
		{
			rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
			if (facing) Flip();
		}
		else
		{
			if (!facing) Flip();
			rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
		}
		if (att==1)
		{
			slideTime1 = 1f;
			ani.SetBool("attack", true);
			att = 0;
		}
		//else if (att==0)
		//{
		//	slideTime += Time.deltaTime;
		//	if (slideTime > MaxSlideTime)
		//	{
		//		ani.SetBool("attack", false);
		//		att=-1;
		//	}
		//}
	}
	void Flip()
	{
		facing = !facing;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	int att = -1;
	float slideTime1;
	//float MaxSlideTime = 1.5f;
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "MainCh")
		{
			att = 1;
			Debug.Log("Kill Player!!!" + att);
		}
	}
}
