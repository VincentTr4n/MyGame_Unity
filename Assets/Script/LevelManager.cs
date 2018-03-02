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

    public string currLevel;

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

    // The function respawn player
    public IEnumerator FixedRespawn()
    {
        Instantiate(DeathEffect, player.transform.position, player.transform.rotation);

        // Hide player 
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        //var pos = currentCP.transform.position;

        //      // Save player position
        //      PlayerPrefs.SetFloat("playerX", pos.x);
        //      PlayerPrefs.SetFloat("playerY", pos.y);
        //      PlayerPrefs.SetFloat("playerZ", pos.z);

        Debug.Log("Player respawn");

        yield return new WaitForSeconds(delay);
		UnityEngine.SceneManagement.SceneManager.LoadScene(currLevel);

        // move the player to positon saved
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-16.37f, -1.64f, 0f);

        //player.enabled = true;
        //// Show player
        //player.GetComponent<Renderer>().enabled = true;
        //player.GetComponent<CircleCollider2D>().enabled = false;
        //player.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
