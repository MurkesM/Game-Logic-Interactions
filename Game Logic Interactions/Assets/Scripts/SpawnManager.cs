using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get => instance; }
    private static SpawnManager instance;

    public GameObject aiPrefab;
    public int amountToSpawn;
    public int amountToPool;

    private List<GameObject> gameObjectPool = new();
    private GameObject currentGameObject;

    private void Awake()
    {
        instance = this;

        CreatePool();
        StartCoroutine(SpawnRoutine());
    }

    private void CreatePool()
    {
        for (int i = 0; i < amountToPool; i++)
            CreateGameObject();
    }

    private GameObject CreateGameObject()
    {
        currentGameObject = Instantiate(aiPrefab, AIPointManager.Instance.startPoint.position, Quaternion.identity);
        currentGameObject.SetActive(false);
        gameObjectPool.Add(currentGameObject);

        return currentGameObject;
    }

    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            currentGameObject = GetObjectFromPool();
            currentGameObject.SetActive(true);

            yield return new WaitForSeconds(.25f);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject gameObject in gameObjectPool)
        {
            if (!gameObject.activeInHierarchy)
                return gameObject;
        }

        return null;
    }
}