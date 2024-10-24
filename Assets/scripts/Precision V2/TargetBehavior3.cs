using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior3 : MonoBehaviour
{
    private ColorSizeController3 colorSizeController;

    private void Start()
    {
        colorSizeController = GetComponent<ColorSizeController3>();
    }

public void Hit()
{
    if (colorSizeController != null) 
    {
        if (colorSizeController.IsOriginalColor()) 
        {
            GameController.Instance.CorrectHit();
            TargetSpawner3.Instance.SpawnNextTarget();
            Destroy(gameObject);
        }
        else
        {
            GameController.Instance.IncorrectHit();
        }
    }
}
    void OnCollisionEnter(Collision collision)
{
    Debug.Log("Target collided with: " + collision.gameObject.name);
}
}