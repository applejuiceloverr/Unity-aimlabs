using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public List<Transform> spawnPoints;
    private Queue<Transform> availableSpawnPoints = new Queue<Transform>();
    private List<GameObject> activeTargets = new List<GameObject>();

    private void OnEnable()
    {
        TargetBehavior.OnTargetHit += ReplaceTarget;
    }

    private void OnDisable()
    {
        TargetBehavior.OnTargetHit -= ReplaceTarget;
    }

    void Start()
    {
        
        foreach (var point in spawnPoints)
        {
            availableSpawnPoints.Enqueue(point);
        }

        
        for (int i = 0; i < 5; i++)
        {
            if (availableSpawnPoints.Count > 0)
            {
                SpawnTarget(availableSpawnPoints.Dequeue());
            }
        }
    }

    void SpawnTarget(Transform spawnPoint)
    {
        GameObject newTarget = Instantiate(targetPrefab, spawnPoint.position, Quaternion.identity);
        TargetBehavior targetBehavior = newTarget.GetComponent<TargetBehavior>();
        if (targetBehavior != null)
        {
            targetBehavior.mySpawnPoint = spawnPoint; 
        }
        activeTargets.Add(newTarget);
    }

public void ReplaceTarget(Transform usedSpawnPoint)
{
    
    availableSpawnPoints.Enqueue(usedSpawnPoint);

    
    activeTargets.RemoveAll(target => target == null);

    
    if (availableSpawnPoints.Count > 0)
    {
        SpawnTarget(availableSpawnPoints.Dequeue());
    }
}
}