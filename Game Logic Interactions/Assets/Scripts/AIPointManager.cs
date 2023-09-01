using System.Collections.Generic;
using UnityEngine;

public class AIPointManager : MonoBehaviour
{
    public static AIPointManager Instance { get => instance; }
    private static AIPointManager instance;

    public Transform startPoint;
    public Transform endPoint;
    public List<Transform> hidePoints = new();

    private void Awake()
    {
        instance = this;
    }

    public Transform GetRandomHidePoint()
    {
        if (hidePoints.Count < 1)
            return null;

        return hidePoints[Random.Range(0, hidePoints.Count - 1)];
    }
}