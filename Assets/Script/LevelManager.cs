using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject currentCP;
    private Control Player;
    public GameObject DeathEffect;
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
    public IEnumerator FixedRespawn()
    {
        Instantiate(DeathEffect, Player.transform.position, Player.transform.rotation);
        Player.enabled = false;
        Player.GetComponent<Renderer>().enabled = false;
        Player.GetComponent<CircleCollider2D>().enabled = false;
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
        Debug.Log("Player respawn");
        yield return new WaitForSeconds(delay);
		pos = currentCP.transform.position;
		//UnityEngine.SceneManagement.SceneManager.LoadScene("test1");
		Player.transform.position = pos;
        Player.enabled = true;
        Player.GetComponent<Renderer>().enabled = true;
        Player.GetComponent<CircleCollider2D>().enabled = true;
        Player.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
