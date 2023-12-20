using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab;
    public float SpawnRange = 9f;
    public float RepeatRate = 1f;
    public float StartDelay = 1f;
    void Start()
    {
        InvokeRepeating("GenerateEnemy", StartDelay, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateEnemy ()
    {
        Instantiate(EnemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }
    private Vector3 GenerateSpawnPosition () 
    {
        float SpawnPositionX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPositionZ = Random.Range(-SpawnRange, SpawnRange);
        Vector3 RandomPos = new Vector3(SpawnPositionX, 0, SpawnPositionZ);
        return RandomPos;
    }
}
