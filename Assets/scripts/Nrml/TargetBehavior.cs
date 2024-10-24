using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public static event System.Action<Transform> OnTargetHit;
    public Transform mySpawnPoint;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Hit()
    {
        OnTargetHit?.Invoke(mySpawnPoint);
        Destroy(gameObject);

        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(1);
            Debug.Log("Current Score: " + scoreManager.score);
        }
    }
}
