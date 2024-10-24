using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager1 : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int lives = 3; 
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
void Start()
{
    if (scoreText == null)
    {
        Debug.LogError("Score Text is not assigned in ScoreManager1");
    }
    else
    {
        scoreText.text = "Score: " + score;
    }

    if (livesText == null)
    {
        Debug.LogError("Lives Text is not assigned in ScoreManager1");
    }
    else
    {
        livesText.text = "Lives: " + lives;
    }
}
public void IncreaseScore(int amount)
{
    score += amount;
    Debug.Log("New Score: " + score); 
    scoreText.text = "Score: " + score;
}

public void IncreaseScoreForRoundCompletion()
{
    Debug.Log("IncreaseScoreForRoundCompletion called"); 
    IncreaseScore(10); 
}
public void DecreaseLives()
{
    if (lives > 0)
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }

    if (lives <= 0)
    {
        
        SceneManager.LoadScene("GameOver");
    }
}

public void ResetGame() 
{
    score = 0;
    lives = 3;
    scoreText.text = "Score: " + score;
    livesText.text = "Lives: " + lives;
     
}
public void RetryGame()
{
    
    ResetGame();
}
public void LoadMainMenu()
{
 
    SceneManager.LoadScene("Menu");
}


}