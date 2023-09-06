using System;

public static class EnemyDataManager
{
    private static int enemyCount;

    public static event Action<int> OnEnemyCountUpdated;

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
}