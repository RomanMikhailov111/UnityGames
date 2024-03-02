using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float SpawnRate = 1.0f;
    public int Score;
    public bool isGameOver;
    public GameObject[] TargetsPrefabs;

    public Button RestartButton;


    public GameObject GameOverPanel;

    public TextMeshProUGUI ScoreText;
    void Start()
    {
        RestartButton.onClick.AddListener(RestartGame);

        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    private void RestartGame()
    {
        string SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneName);
    }

    public void UpdateScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
        Debug.Log (Score.ToString ());

        if (Score < 0)
        {
            isGameOver = true;
            GameOverPanel.SetActive(true);
        }
    }

    private IEnumerator SpawnTarget ()
    {
        while (!isGameOver)
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
