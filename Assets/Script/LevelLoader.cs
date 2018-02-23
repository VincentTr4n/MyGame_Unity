using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	private bool InZone;
	public string levelName;
	public GameObject OpenDoor;

	// Use this for initialization
	void Start () {
		InZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && InZone)
		{
			OpenDoor.SetActive(true);
			Application.LoadLevel(levelName);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "MainCh")
		{
			InZone = true;
			Debug.Log("OK, In zone");
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "MainCh")
		{
			InZone = false;
			Debug.Log("OK, Out zone");
		}
	}
}
