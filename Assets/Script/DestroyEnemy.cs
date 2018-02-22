using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

    // Use this for initialization
    bool Enemy = false;
    public Transform EnemyCheck;
    float EnemyRadius = 0.2f;
    public LayerMask WhatIsEnemy;
    void Start () {
		
	}
    void OnTriggerEnter2D()
    {
        if (Enemy)
            return;
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        Enemy = Physics2D.OverlapCircle(EnemyCheck.position, EnemyRadius, WhatIsEnemy);
    }
}
