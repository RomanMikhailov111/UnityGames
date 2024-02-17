using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float SpawnRate = 1.0f;
    public int Score;
    public GameObject[] TargetsPrefabs;


    public TextMeshProUGUI ScoreText;
    void Start()
    {
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
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
