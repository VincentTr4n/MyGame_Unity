using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {

    // Use this for initialization
    public bool grounded1 = false;
    public Transform groundCheck1;
    float groundRadius1 = 0f;
    public LayerMask WhatIsGround1;

    public float JumpH;
    bool JumpCheck;
    void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
        grounded1 = Physics2D.OverlapCircle(groundCheck1.position, groundRadius1, WhatIsGround1);
        if (grounded1)
        {
            JumpCheck = !JumpCheck;
        }
        if (JumpCheck)
            transform.Translate(Vector3.up * JumpH * Time.deltaTime);
        else transform.Translate(Vector3.down * JumpH * Time.deltaTime);
    }
}
