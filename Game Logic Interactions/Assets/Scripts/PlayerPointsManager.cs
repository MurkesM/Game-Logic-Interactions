public static class PlayerPointsManager
{
    private static int currentPoints = 0;

    public static void AddPoints(int points)
    {
        currentPoints += points;
    }

    public static void RemovePoints(int points)
    {
        currentPoints -= points;
    }
}