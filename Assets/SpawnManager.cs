using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjects;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn() 
    {
        index = UnityEngine.Random.Range(0, spawnObjects.Length);
        Instantiate(spawnObjects[index], transform.position, spawnObjects[index].transform.rotation);
    }
}
