using System;

public static class PlayerPointsManager
{
    private static int currentPoints = 0;

    public static event Action<int> OnPointsUpdated;

    public static void AddPoints(int points)
    {
        currentPoints += points;
        OnPointsUpdated?.Invoke(currentPoints);
    }

    public static void RemovePoints(int points)
    {
        currentPoints -= points;
        OnPointsUpdated?.Invoke(currentPoints);
    }
}