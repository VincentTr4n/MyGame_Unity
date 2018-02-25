using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    // Current Player
    public GameObject currentCP;

    // Player Controlller
    private Control Player;

    // DeathEffect
    public GameObject DeathEffect;

    // Time delay to respawn
    public float delay;
	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<Control>();
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Respawn()
    {
        StartCoroutine("FixedRespawn");
    }
	Vector3 pos { get; set; }

    // The function respawn player
    public IEnumerator FixedRespawn()
    {
        Instantiate(DeathEffect, Player.transform.position, Player.transform.rotation);
        
        // Hide player 
        Player.enabled = false;
        Player.GetComponent<Renderer>().enabled = false;
        Player.GetComponent<CircleCollider2D>().enabled = false;
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
		pos = currentCP.transform.position;
		Debug.Log("Player respawn");

        yield return new WaitForSeconds(delay);
		//UnityEngine.SceneManagement.SceneManager.LoadScene("Level_01");

        // move the player to positon saved
		Player.transform.position = pos;
        Player.enabled = true;
        // Show player
        Player.GetComponent<Renderer>().enabled = true;
        Player.GetComponent<CircleCollider2D>().enabled = false;
        Player.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
