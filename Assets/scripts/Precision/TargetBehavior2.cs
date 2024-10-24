using UnityEngine;
using System.Collections.Generic;
public class TargetBehavior2 : MonoBehaviour
{
    private ColorSizeController colorSizeController;
    private ScoreManager scoreManager;
    public static event System.Action OnTargetHit;

    private void Start()
    {
        colorSizeController = GetComponent<ColorSizeController>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

public void Hit()
{
    Debug.Log("Hit method called");

    colorSizeController.Hit();

    if (colorSizeController.IsColorOne()) 
    {
        scoreManager.IncreaseScore(1);
    }

    OnTargetHit?.Invoke(); // Make sure this line is present
}
}
