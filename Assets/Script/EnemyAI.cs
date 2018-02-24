using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{

	// what to chase?
	public Transform targer;

	// Time upate our path
	public float updateRate = 2f;

	// Caching
	private Seeker seeker;
	private Rigidbody2D rb;

	// calculate path
	public Path path;

	// the AI
	public float speed = 300f;
	public ForceMode2D fmode;

	[HideInInspector]
	public bool pathIsEnded = false;

	// max distance from AI to a waypoint for it to continue to the next waypoint
	public float nextWayPointDis = 3;

	// The waypoint we are currently moving towards
	private int currentWayPoint = 0;


	void Start()
	{
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		if (targer == null)
		{
			Debug.Log("Target is null (not found player)!!!");
			return;
		}

		// start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath(transform.position, targer.position, OnPathComplete);

		StartCoroutine(UpdatePath());
	}

	IEnumerator UpdatePath()
	{
		if (targer == null) yield return null;

		seeker.StartPath(transform.position, targer.position, OnPathComplete);
		yield return new WaitForSeconds(1f / updateRate);

		StartCoroutine(UpdatePath());
	}

	public void OnPathComplete(Path p)
	{
		Debug.Log("We got a path, Did it have an error?" + p.error);
		if (!p.error)
		{
			path = p;
			currentWayPoint = 0;
		}
	}

	void FixedUpdate()
	{
		if (targer == null) return;
		if (path == null) return;
		if (currentWayPoint >= path.vectorPath.Count)
		{
			if (pathIsEnded) return;

			Debug.Log("End of path reached");
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;

		Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		// Move the AI
		rb.AddForce(dir, fmode);

		if (Vector3.Distance(transform.position,path.vectorPath[currentWayPoint]) < nextWayPointDis)
		{
			currentWayPoint++;
			return;
		}
	}
}
