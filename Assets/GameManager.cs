using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameType
{
    Easy,
    Medium,
    Hard
}
public class GameManager : MonoBehaviour
{
    public float EasySpawnRate = 1.5f;
    public float MediumSpawnRate = 1.0f;
    public float HardSpawnRate = 0.5f;
    public int Score;
    public bool isGameOver;
    public GameObject[] TargetsPrefabs;

    public Button RestartButton;
    public Button EasyStartButton;
    public Button MediumStartButton;
    public Button HardStartButton;


    public GameObject GameOverPanel;
    public GameObject StartGamePanel;

    public TextMeshProUGUI ScoreText;
    void Start()
    {
        RestartButton.onClick.AddListener(RestartGame);

        EasyStartButton.onClick.AddListener(EasyStartGame);
        MediumStartButton.onClick.AddListener(MediumStartGame);
        HardStartButton.onClick.AddListener(HardStartGame);

        UpdateScore(0);
    }   

    private void StartGame(GameType type)
    {
        float TimeToSpawn = 0;

        switch (type)
        {
            case GameType.Easy:
                TimeToSpawn = EasySpawnRate;
                break;
            case GameType.Medium:
                TimeToSpawn = MediumSpawnRate;
                break;
            case GameType.Hard:
                TimeToSpawn = HardSpawnRate;
                break;
        }

        StartCoroutine(SpawnTarget(TimeToSpawn));
        StartGamePanel.SetActive(false);
    }
    private void HardStartGame()
    {

        StartGame(GameType.Hard);
    }

    private void MediumStartGame()
    {
        StartGame(GameType.Medium);
    }

    private void EasyStartGame()
    {

        StartGame(GameType.Easy);
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

    private IEnumerator SpawnTarget (float TimeSpawnRate)
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(TimeSpawnRate);
            int Index = Random.Range(0, TargetsPrefabs.Length);
            Instantiate(TargetsPrefabs[Index]);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
