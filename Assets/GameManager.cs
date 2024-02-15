using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float SpawnRate = 1.0f;
    public int Score;
    public GameObject[] TargetsPrefabs; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    public void AddScore(int score)
    {
        Score += score;
        Debug.Log (Score.ToString ());
    }

    private IEnumerator SpawnTarget ()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int Index = Random.Range(0, TargetsPrefabs.Length);
            Instantiate(TargetsPrefabs[Index]);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
