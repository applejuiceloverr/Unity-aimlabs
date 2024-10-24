using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public TargetSpawner1 targetSpawner;
    private int currentTargetNumber = 1;
    private bool allTargetsHit = false;
    public ScoreManager1 scoreManager;
    public int lives = 3;
    public LEDControl ledControl;


    void Start()
    {
        TargetBehavior1.OnTargetHit += CheckTargetHit;
        targetSpawner.SpawnTargets();
    }

void Update()
{
    if (Input.GetMouseButtonDown(0)) 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TargetBehavior1 target = hit.collider.GetComponent<TargetBehavior1>();
            if (target != null)
            {
                target.Hit();
            }
        }
    }

        
        if (allTargetsHit)
        {
            RespawnTargets();
            allTargetsHit = false; 
        }
    }
void CheckTargetHit(Transform hitTarget)
{
    TargetBehavior1 targetBehavior = hitTarget.GetComponent<TargetBehavior1>();
    if (targetBehavior != null)
    {
        if (targetBehavior.number == currentTargetNumber)
        {
            currentTargetNumber++;
            if (currentTargetNumber > targetSpawner.spawnPoints.Length)
            {
                allTargetsHit = true; 
            }
        }
        else
        {
            
            if (ledControl != null)
            {
                StartCoroutine(ledControl.SetWrong());
            }
            scoreManager.DecreaseLives(); 
            if (scoreManager.lives <= 0) 
            {
                scoreManager.ResetGame(); 
            }
            else
            {
                RespawnTargets();
            }
        } 
    }
}

private void RespawnTargets()
{
    if (currentTargetNumber > targetSpawner.spawnPoints.Length)
    {
        scoreManager.IncreaseScoreForRoundCompletion();
    }

    ShuffleSpawnPoints();
    targetSpawner.DestroyTargets();
    targetSpawner.SpawnTargets();
    currentTargetNumber = 1;
}
private void ShuffleSpawnPoints()
{
    for (int i = 0; i < targetSpawner.spawnPoints.Length; i++)
    {
        Transform temp = targetSpawner.spawnPoints[i];
        int randomIndex = Random.Range(i, targetSpawner.spawnPoints.Length);
        targetSpawner.spawnPoints[i] = targetSpawner.spawnPoints[randomIndex];
        targetSpawner.spawnPoints[randomIndex] = temp;
    }
}
}