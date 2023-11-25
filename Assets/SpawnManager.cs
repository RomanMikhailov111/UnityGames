using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public float startDelay;
    public float repeatRate;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Spawn",startDelay,repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawn ()
    {
        if (playerController.isGameOver)
        {
            return;
        }

        var index = Random.Range(0, spawnObjects.Length);
        Instantiate(spawnObjects[index], transform.position, spawnObjects[index].transform.rotation);
    }
}

