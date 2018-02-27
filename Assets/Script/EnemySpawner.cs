using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public enum SpawnState { Spawning, Watting, Counting }

    [System.Serializable]
    public class Enemy
    {
        public string Name;
        public Transform TEnemy;
        public int Count;
        public float DelayTime;
    }

    public Enemy[] enemies;
    public Transform[] spawnPoints;

    int nextEnemy;
    public float timeBetween = 5f;
    float countDown;

    public SpawnState state;

    float searchCountDown = 1f;

    public bool isStart = false;

    // Use this for initialization
    void Start()
    {
        countDown = timeBetween;
        state = SpawnState.Counting;

        if (spawnPoints.Length == 0) Debug.Log("No spawn point detect");
    }

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            if (state == SpawnState.Watting)
            {
                if (!EnemyIsAlive())
                {

                }
                else return;
            }

            if (countDown <= 0f)
            {
                if (state != SpawnState.Spawning)
                {
                    Debug.Log("Start spawning");
                    StartCoroutine(SpawnEnemy(enemies[nextEnemy]));
                }
            }
            else
            {
                countDown -= Time.deltaTime;
            }
        }
    }

    IEnumerator SpawnEnemy(Enemy enemy)
    {
        Debug.Log("Spawning : " + enemy.Name);
        state = SpawnState.Spawning;

        for (int i = 0; i < enemy.Count; i++)
        {
            SpawnHelper(enemy.TEnemy);
            yield return new WaitForSeconds(1f / enemy.DelayTime);
        }

        state = SpawnState.Watting;
        yield break;
    }
    void SpawnHelper(Transform tenemy)
    {
        // Random spawn point
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var clone = Instantiate(tenemy, point.position, point.rotation);
        var player = GameObject.FindGameObjectWithTag("Player");
        
        // Set component for clone object 
        clone.GetComponent<KillPlayer>().levelM = FindObjectOfType<LevelManager>();
        clone.GetComponent<KillPlayer>().theme = GameObject.Find("SoundPlayer").GetComponent<AudioSource>();
        clone.GetComponent<KillPlayer>().theme = GameObject.Find("ThemeMusic").GetComponent<AudioSource>();
        clone.gameObject.GetComponent<EnemyAI>().targer = player.transform;

        Debug.Log("Spawning enemy : " + tenemy.name);
    }

    void SpawnCompleted()
    {
        Debug.Log("Complete!!");
        state = SpawnState.Counting;

        countDown = timeBetween;
        if (nextEnemy + 1 > enemies.Length)
        {
            // next enemy more than collection length -> down to 0
            nextEnemy = 0;
            Debug.Log("All completed!");
        }
        else nextEnemy++;
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            return GameObject.FindGameObjectWithTag("FlyEnemy") != null;
        }
        return true;
    }
}
