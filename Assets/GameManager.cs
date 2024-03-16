using System;
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
    public GameSetting EasySetting;
    public GameSetting MediumSetting;
    public GameSetting HardSetting;

    public int GameScore;
    public bool isGameOver;
    public GameObject[] TargetsPrefabs;

    public Button RestartButton;
    public Button EasyStartButton;
    public Button MediumStartButton;
    public Button HardStartButton;

    public GameObject GameOverPanel;
    public GameObject StartGamePanel;

    public TextMeshProUGUI ScoreText;

    public GameObject HealthPrefab;
    public GameObject HealthParent;
    public GameObject[] GameHealth;

    public float Timer;
    public bool isTimerRunning;
    public TextMeshProUGUI TimerText;

    void Start()
    {
        RestartButton.onClick.AddListener(RestartGame);

        EasyStartButton.onClick.AddListener(EasyStartGame);
        MediumStartButton.onClick.AddListener(MediumStartGame);
        HardStartButton.onClick.AddListener(HardStartGame);

        UpdateScore(0);
    }
    void Update()
    {
        if (isTimerRunning == true)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                Timer = 0;
                isTimerRunning = false;
                GameOver();
            }
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(Timer / 60f);
        int seconds = Mathf.FloorToInt(Timer % 60f);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void StartGame(GameType type)
    {
        GameSetting gameSetting = null;

        switch (type)
        {
            case GameType.Easy:
                gameSetting = EasySetting;
                break;
            case GameType.Medium:
                gameSetting = MediumSetting;
                break;
            case GameType.Hard:
                gameSetting = HardSetting;
                break;
        }

        Timer = gameSetting.GameTime;
        isTimerRunning = true;

        GameHealth =  new GameObject[gameSetting.Health];

        for (int i = 0; i < gameSetting.Health; i++)
        {
            var Health = Instantiate(HealthPrefab, HealthParent.transform);
            GameHealth[i] = Health;
        }

        StartCoroutine(SpawnTarget(gameSetting.SpawnRate));
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
        GameScore += score;
        ScoreText.text = GameScore.ToString();
        Debug.Log (GameScore.ToString ());

        if (score < 0)
        {
            bool isLastLifeDisable = false;
            int LastLife = GameHealth.Length - 1;
            for (int i = 0; i < GameHealth.Length; i++)
            {
                if (GameHealth[i].activeSelf)
                {
                    GameHealth[i].SetActive(false);
                    isLastLifeDisable = i == LastLife;
                    break;
                }
            }
            
            if (isLastLifeDisable == true) 
            {
                GameOver();
                return;
            }
        }

        if (GameScore < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        GameOverPanel.SetActive(true);
    }

    private IEnumerator SpawnTarget (float TimeSpawnRate)
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(TimeSpawnRate);
            int Index = UnityEngine.Random.Range(0, TargetsPrefabs.Length);
            Instantiate(TargetsPrefabs[Index]);
        }
    }
}

[Serializable]
public class GameSetting
{
    public float SpawnRate;
    public int Health;
    public int GameTime;
}
