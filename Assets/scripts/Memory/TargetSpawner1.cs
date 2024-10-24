using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner1 : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints = new Transform[6];

    private List<GameObject> currentTargets = new List<GameObject>();

    public void SpawnTargets()
    {
        int number = 1; 
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                GameObject newTarget = Instantiate(targetPrefab, spawnPoint.position, spawnPoint.rotation);
                TargetBehavior1 targetBehavior = newTarget.GetComponent<TargetBehavior1>();
                if (targetBehavior != null)
                {
                    targetBehavior.mySpawnPoint = spawnPoint;
                    targetBehavior.number = number++; 
                    currentTargets.Add(newTarget);
                }
            }
        }
    }

    public void DestroyTargets()
    {
        foreach (GameObject target in currentTargets)
        {
            Destroy(target);
        }
        currentTargets.Clear();
    }
}