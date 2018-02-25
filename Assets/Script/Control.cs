using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
	//
	//Run

	public float MaxSp = 10.0f;
	bool facing = true;
	//
	//Character and animator

	private Rigidbody2D myR;
	private Animator ani;
	//
	//GroundCheck

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask WhatIsGround;
	//
	//jump

	public float JumpF = 200f;
	public float jumpH = 6f;
	//
	//Slide

	private bool slide = false;
	public float sildeTime = 3f;
	public float MaxSildeTime = 1.5f;
	//
	//Munition

	public Transform firePoint;
	public GameObject munition;

	//
	//
	public float knockBack;
	public float knockBackLength;
	public float knockBackCount;
	public bool knockBackRight;

	//
	//
	public GameObject melee;

	// Use this for initialization
	void Start()
	{
		myR = GetComponent<Rigidbody2D>();
		GetComponent<Rigidbody2D>().freezeRotation = true;
		ani = GetComponent<Animator>();
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//Ground Check;
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
	}

	void Update()
	{

        // Set animation
		ani.SetBool("Ground", grounded);
		ani.SetFloat("vSpeed", myR.velocity.y);
		
        //Monvement
		float move = Input.GetAxis("Horizontal");

		if (knockBackCount <= 0)
		{
			if (move < 0)
			{
				transform.Translate(Vector3.left * MaxSp * Time.deltaTime);
				ani.SetBool("shoot", attacking = false);
			}
			if (move > 0)
			{
				transform.Translate(Vector3.right * MaxSp * Time.deltaTime);
				ani.SetBool("shoot", attacking = false);
			}
		} else
		{
            // Knockback player when hurt enemy
			if (knockBackRight) GetComponent<Rigidbody2D>().velocity = new Vector2(-knockBack, knockBack);
			if(!knockBackRight) GetComponent<Rigidbody2D>().velocity = new Vector2(knockBack, knockBack);
			knockBackCount -= Time.deltaTime;
		}

		//
		//animation run

		ani.SetFloat("Speed", Mathf.Abs(move));

		//
		//Flip character;

		if (move < 0 && facing) Flip();
        else if (move > 0 && !facing) Flip();

        // Jump with space key
        if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			ani.SetBool("Ground", false);
			myR.AddForce(new Vector2(0, JumpF));
			myR.velocity = new Vector2(0, jumpH);
			GetComponent<AudioSource>().Play();
		}

        // Slide with left control key
		if (Input.GetKeyDown(KeyCode.LeftControl) && !slide)
		{
			sildeTime = 1f;
			ani.SetBool("Slide", true);
			gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
			slide = true;
		}
		if (slide)
		{
            // time for slide
			sildeTime += Time.deltaTime;
			if (sildeTime > MaxSildeTime)
			{
				slide = false;
				ani.SetBool("Slide", false);
				gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
				gameObject.GetComponent<CircleCollider2D>().enabled = false;
			}
		}

        // Shoot with T key
		if (Input.GetKeyDown(KeyCode.T) && !attacking)
		{
			Instantiate(munition, firePoint.position, firePoint.rotation);
			ani.SetBool("shoot", attacking = true);
			attTime = 1f;
		}

		if (attacking)
		{
            // Time delay shotting
			attTime += Time.deltaTime;
			if (attTime > 1.2f) ani.SetBool("shoot", attacking = false);
		}

		//ani.SetBool("shoot", false);

        // Melee with F key
		if (Input.GetKeyDown(KeyCode.F) && !isMelee)
		{
			ani.SetBool("melee", isMelee = true);
			timeMelee = 1f;
			melee.SetActive(true);
		}

		if (isMelee)
		{
            // Time delay melee attacking
			timeMelee += Time.deltaTime;
			if (timeMelee > 1.08f)
			{
				ani.SetBool("melee", isMelee = false);
				melee.SetActive(false);
			}
		}


	}

	//
	//
	bool attacking = false;
	float attTime;

	//
	//
	bool isMelee = false;
	float timeMelee;


	//Flip function
	void Flip()
	{
		facing = !facing;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
