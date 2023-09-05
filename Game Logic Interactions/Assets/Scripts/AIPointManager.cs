using System.Collections.Generic;
using UnityEngine;

public class AIPointManager : MonoBehaviour
{
    public static AIPointManager Instance { get => instance; }
    private static AIPointManager instance;

    public Transform startPoint;
    public Transform endPoint;
    public List<Transform> hidePoints = new();
    public int index = 0;

    private void Awake()
    {
        instance = this;
    }

    public Transform GetUniqueHidePoint()
    {
        if (hidePoints.Count < 1 || index > hidePoints.Count - 1)
            return null;

        var hidePoint = hidePoints[index];
        index++;

        return hidePoint;
    }
}