using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjects;
    private int index;
    public float startDelay;
    public float repeatRate;
    public float spawnRange;
    public float spawnPosZ;
    // Start is called before the first frame update
    public bool gameOver;
    void Start()
    {
        InvokeRepeating("Spawn", repeatRate, startDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn() 
    {
        if (gameOver)
        {
            return;
        }

        index = UnityEngine.Random.Range(0, spawnObjects.Length);
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-8, 8), 0, spawnPosZ);
        Instantiate(spawnObjects[index], spawnPos, spawnObjects[index].transform.rotation);
    }
   
}
