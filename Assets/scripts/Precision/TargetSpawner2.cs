using UnityEngine;
using System.Collections.Generic;
public class TargetSpawner2 : MonoBehaviour
{
    public GameObject targetPrefab;
    public List<Transform> spawnPoints;
    private int currentSpawnIndex = 0;
    private GameObject currentTarget;

  public void OnEnable()
    {
        TargetBehavior2.OnTargetHit += SpawnNextTarget;
    }

    private void Start()
    {
        TargetBehavior2.OnTargetHit += SpawnNextTarget;
        SpawnTarget();
    }

    private void OnDisable()
    {
        TargetBehavior2.OnTargetHit -= SpawnNextTarget;
    }


    public void SpawnNextTarget()
    {  Debug.Log("Spawning next target");
        if (currentTarget != null)
        {
            Destroy(currentTarget);
        }
        currentSpawnIndex = (currentSpawnIndex + 1) % spawnPoints.Count;
        SpawnTarget();
    }

public void SpawnTarget()
{
    Debug.Log("SpawnTarget method called");

    currentTarget = Instantiate(targetPrefab, spawnPoints[currentSpawnIndex].position, Quaternion.identity);
    currentTarget.GetComponent<ColorSizeController>().ResetSize();
}
}
