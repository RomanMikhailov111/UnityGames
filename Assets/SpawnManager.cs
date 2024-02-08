using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] EnemyPrefabs;
    public GameObject PowerUpPrefab;
    public GameObject PowerUpRockets;
    public float SpawnRange = 9f;
    public float RepeatRate = 1f;
    public float StartDelay = 1f;
    public int EnemyCount;
    public int EnemyWin;
    public GameObject WinWindow;
    void Start()
    {
        //InvokeRepeating("GenerateEnemy", StartDelay, RepeatRate);
        GenerateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (WinWindow.activeSelf)
        {
            return;
        }

        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            if (EnemyCount == EnemyWin)
            {
                WinWindow.SetActive(true);
                return;
            }
            EnemyCount++; //EnemyCount = EnemyCount + 1;
            GenerateEnemy();
        }
    }
    private void GenerateEnemy ()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            int EnemyNumbers = Random.Range(0, EnemyPrefabs.Length);
            Instantiate(EnemyPrefabs[EnemyNumbers], GenerateSpawnPosition(), Quaternion.identity);

            if (EnemyCount%2 == 0) 
            {
                Instantiate(PowerUpPrefab, GenerateSpawnPosition(), PowerUpPrefab.transform.rotation);
            }

            if (EnemyCount%3 == 0)
            {
                Instantiate(PowerUpRockets, GenerateSpawnPosition(), PowerUpRockets.transform.rotation);
            }
        }
        
    }
    private Vector3 GenerateSpawnPosition () 
    {
        float SpawnPositionX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPositionZ = Random.Range(-SpawnRange, SpawnRange);
        Vector3 RandomPos = new Vector3(SpawnPositionX, 0, SpawnPositionZ);
        return RandomPos;
    }
}
