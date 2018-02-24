using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    //following target
    public Transform target;
	public bool isCamera;
	public GameObject impactEffect;

	Vector3 v = Vector3.zero;
    public float Time = .15f;
    void FixedUpdate()
    {
        Vector3 tPosition = target.position;
        tPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, tPosition, ref v, Time);
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!isCamera)
		{
			var clone = Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			DeleteClones();
		}
	}
	void DeleteClones()
	{
		var clones = GameObject.FindGameObjectsWithTag("EffectClone");
		for (int i = 0; i < clones.Length - 1; i++) Destroy(clones[i]);
	}
}
