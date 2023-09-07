using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnGameOver;
    public event Action OnGameWin;

    public bool gameOver = false;
    public bool gameWon = false;

    private void Awake()
    {
        Instance = this;

        EnemyDataManager.OnEnemyCountUpdated += CheckEnemyCount;
    }

    private void OnDestroy()
    {
        EnemyDataManager.OnEnemyCountUpdated -= CheckEnemyCount;
    }

    public void CheckEnemyCount(int enemyCount)
    {
        if (gameWon || enemyCount > 0 )
            return;

        gameWon = true;
        OnGameWin?.Invoke();

        gameOver = true;
        OnGameOver?.Invoke();
    }
}