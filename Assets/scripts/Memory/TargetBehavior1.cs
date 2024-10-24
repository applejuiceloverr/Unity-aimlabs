using System.Collections;
using UnityEngine;
using TMPro;

public class TargetBehavior1 : MonoBehaviour
{
    public static event System.Action<Transform> OnTargetHit;
    public Transform mySpawnPoint;
    public int number;
    private TextMeshPro textMesh; 

    private ScoreManager scoreManager;
    private bool isHit = false;
    private bool numbersVisible = true;

    private void Start()
    {
        mySpawnPoint = transform;
        scoreManager = FindObjectOfType<ScoreManager>();

        textMesh = GetComponentInChildren<TextMeshPro>(); 
        Debug.Log(textMesh == null ? "textMesh is null" : "textMesh is not null");
        textMesh.text = number.ToString();
        StartCoroutine(HideNumberAfterSeconds(5));
    }
IEnumerator HideNumberAfterSeconds(int seconds)
{
    yield return new WaitForSeconds(seconds);
    textMesh.text = "";
    numbersVisible = false; 
}

    public void Hit()
    {
        if (!isHit && !numbersVisible) 
        {
            
            OnTargetHit?.Invoke(mySpawnPoint);
            isHit = true;
            textMesh.text = "";
        }
    }

    public bool IsHit()
    {
        return isHit;
    }
}