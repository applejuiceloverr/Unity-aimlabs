using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float timeLeft = 60f; 
    public int score = 0;
    public Text scoreText; 
public TextMeshProUGUI timerText;

private void Awake()
{
    if (Instance == null) Instance = this;
    else if (Instance != this) Destroy(gameObject);


}
void Update()
{
    timeLeft -= Time.deltaTime;
    Debug.Log("Time Left: " + timeLeft);

    
    scoreText.text = "Score: " + score;
    timerText.text = "Timer: " + timeLeft.ToString("F2");

    if (timeLeft <= 0)
    {
        SceneManager.LoadScene("GameOver 1");
    }
}

    public void CorrectHit()
    {
        score++; 
        timeLeft += 5f; 
    }

    public void IncorrectHit()
    {
        timeLeft -= 10f; 
    }
}