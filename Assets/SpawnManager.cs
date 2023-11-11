using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool Vertical;
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
        Vector3 spawnPos;
        Vector3 spawnPosX = new Vector3(UnityEngine.Random.Range(-8, 8), 0, spawnPosZ);
        Vector3 spawnPosYsideRight = new Vector3(spawnPosZ, 0, UnityEngine.Random.Range(-8, 8));
        Vector3 spawnPosYsideLeft= new Vector3(-spawnPosZ, 0, UnityEngine.Random.Range(-8, 8));

        Vector3 side = Vector3.zero;
        if (Vertical)
        {
            int random = UnityEngine.Random.Range(0, 2);
            if (random == 0)
            {
                side = Vector3.left;
                spawnPos = spawnPosYsideLeft;
            }
            else 
            { 
                side = Vector3.right;
                spawnPos = spawnPosYsideRight;
            }
        } 
        else
        {
            spawnPos = spawnPosX;
        }
       var spawnobject = Instantiate(spawnObjects[index], spawnPos, spawnObjects[index].transform.rotation);

      var spawnobjectMoveForward =  spawnobject.GetComponent<MoveForward>();
        if (side != Vector3.zero)
        {
            spawnobjectMoveForward.ChangeSide(side);
        } 
    }
   
}
