using System;

public static class EnemyDataManager
{
    private static int enemyCount = 0;
    private static int enemyReachedEndCount = 0;

    public static event Action<int> OnEnemyCountUpdated;
    public static event Action<int> OnEnemyReachedEndCountUpdated;

    public static void IncrementEnemyCount()
    {
        enemyCount++;

        OnEnemyCountUpdated?.Invoke(enemyCount);
    }

    public static void DecrementEnemyCount()
    {
        enemyCount--;

        OnEnemyCountUpdated?.Invoke(enemyCount);
    }

    public static void IncrementEnemyReachedEndCount()
    {
        enemyReachedEndCount++;

        OnEnemyReachedEndCountUpdated?.Invoke(enemyReachedEndCount);
    }
}