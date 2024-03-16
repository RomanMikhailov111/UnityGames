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
                isGameOver = true;
                GameOverPanel.SetActive(true);
                return;
            }
        }

        if (GameScore < 0)
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
            int Index = UnityEngine.Random.Range(0, TargetsPrefabs.Length);
            Instantiate(TargetsPrefabs[Index]);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class GameSetting
{
    public float SpawnRate;
    public int Health;
}
