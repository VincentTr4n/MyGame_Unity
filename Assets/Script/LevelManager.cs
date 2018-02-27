using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    // Current Player
    public GameObject currentCP;

    // Player Controlller
    private Control player;

    // DeathEffect
    public GameObject DeathEffect;

    // Time delay to respawn
    public float delay;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Control>();
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
        Instantiate(DeathEffect, player.transform.position, player.transform.rotation);
        
        // Hide player 
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<CapsuleCollider2D>().enabled = false;
		pos = currentCP.transform.position;
		Debug.Log("Player respawn");

        yield return new WaitForSeconds(delay);
		//UnityEngine.SceneManagement.SceneManager.LoadScene("Level_01");

        // move the player to positon saved
		player.transform.position = pos;
        player.enabled = true;
        // Show player
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
