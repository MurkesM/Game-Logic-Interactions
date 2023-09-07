using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text playerScoreText;
    public Text enemyCountText;
    public Text timeRemainingText;
    public Text gameOverText;

    public float timeToEnd = 60f;
    private float timeRemaining = 1;

    private void Awake()
    {
        Instance = this;

        PlayerPointsManager.OnPointsUpdated += SetScoreText;
        EnemyDataManager.OnEnemyCountUpdated += SetEnemyCountText;
    }

    private void Start()
    {
        GameManager.Instance.OnGameWin += SetGameWonUI;
    }

    private void Update()
    {
        SetTimeRemainingText();
    }

    private void OnDestroy()
    {
        PlayerPointsManager.OnPointsUpdated -= SetScoreText;
        EnemyDataManager.OnEnemyCountUpdated -= SetEnemyCountText;
        GameManager.Instance.OnGameWin -= SetGameWonUI;
    }

    private void SetScoreText(int score)
    {
        playerScoreText.text = $"Score: {score}";
    }

    private void SetEnemyCountText(int enemyCount)
    {
        enemyCountText.text = $"Enemy Count: {enemyCount}";
    }

    private void SetTimeRemainingText()
    {
        if (timeRemaining <= 0)
            return;

        timeRemaining = timeToEnd - Time.time;

        timeRemainingText.text = $"Time Remaining: {Math.Round(timeRemaining, 2)}";
    }

    private void SetGameWonUI()
    {
        gameOverText.gameObject.SetActive(true);
    }
}