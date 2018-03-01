using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour {

    public Transform targer;
    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        targer = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = (Vector2)targer.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }
}
