using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner3 : MonoBehaviour
{
    public static TargetSpawner3 Instance;

    public GameObject targetPrefab;
    public Transform[] spawnPoints;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        SpawnNextTarget(); // Spawn a target at the start of the game
    }

    public void SpawnNextTarget()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(targetPrefab, spawnPoints[index].position, Quaternion.identity);
    }
}