using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
    float speed = 600f;
    // Update is called once per frame
    void Start()
    {
        
    }
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}