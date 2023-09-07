using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnGameOver;
    public event Action OnGameWin;
    public event Action OnGameLoss;

    public bool gameOver = false;
    public bool gameWon = false;
    public bool gameLoss = false;

    private void Awake()
    {
        Instance = this;

        EnemyDataManager.OnEnemyCountUpdated += CheckEnemyCount;
        EnemyDataManager.OnEnemyReachedEndCountUpdated += CheckEnemyReachedEndCount;
    }

    private void OnDestroy()
    {
        EnemyDataManager.OnEnemyCountUpdated -= CheckEnemyCount;
        EnemyDataManager.OnEnemyReachedEndCountUpdated -= CheckEnemyReachedEndCount;
    }

    public void CheckEnemyCount(int enemyCount)
    {
        if (gameOver || enemyCount > 0 )
            return;

        gameWon = true;
        OnGameWin?.Invoke();

        gameOver = true;
        OnGameOver?.Invoke();
    }

    public void CheckEnemyReachedEndCount(int enemyReachedEndCount)
    {
        if (gameOver || enemyReachedEndCount < SpawnManager.Instance.amountToSpawn / 2)
            return;

        print(enemyReachedEndCount);

        gameLoss = true;
        OnGameLoss?.Invoke();

        gameOver = true;
        OnGameOver?.Invoke();
    }
}