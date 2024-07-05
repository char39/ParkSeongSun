using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int spawnCount = 0;
    public int maxSpawnCount = 10;
    public float spawnTime = 3.0f;
    public float timePrev;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public static int killCount = 0;
    public Text killCountText;
    void Start()
    {
        killCount = 0;
        spawnPoints = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        timePrev = Time.time;
        spawnCount = GameObject.FindGameObjectsWithTag("ENEMY").Length;
    }

    void Update()
    {
        KillCountUpdate();
        EnemySpawn();
    }
    public void KillCountUpdate()
    {
        killCountText.text = $"Kill : <color=#FFAAAA>{killCount.ToString()}</color>";
    }

    private void EnemySpawn()
    {
        spawnCount = GameObject.FindGameObjectsWithTag("ENEMY").Length;
        if (Time.time - timePrev > spawnTime)
        {
            if (spawnCount < maxSpawnCount)
            {
                int i = Random.Range(1, spawnPoints.Length);
                Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
                timePrev = Time.time;
            }
        }
    }
}
