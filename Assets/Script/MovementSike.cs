using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSike : MonoBehaviour {
    bool facing = true;
    // Use this for initialization
    public float speed;
    public bool moveR;
    //Wall Check
    bool wall = false;
    public Transform WallCheck;
    float WallRadius = 0.2f;
    public LayerMask WhatIsWall;
    void Start () {
	}
        
	
	// Update is called once per frame
	void Update () {
        wall = Physics2D.OverlapCircle(WallCheck.position, WallRadius, WhatIsWall);
        if (wall )
        {
            moveR = !moveR;
        }
        
        if(moveR)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
		
	}
    void Flip()
    {
        facing = !facing;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
