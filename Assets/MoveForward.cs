using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float slowSpeed;
    public bool enemy;
    public SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        slowSpeed = speed / 3;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (enemy && spawnManager.gameOver)
        {
            return; 
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void SlowDown ()
    {
        speed -= slowSpeed;
        if (speed <= 0)
        {
            Destroy(gameObject);
        }
    }
}
