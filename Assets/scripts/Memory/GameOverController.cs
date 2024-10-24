using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RetryGame()
    {
    
        SceneManager.LoadScene("MemoryGame");
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("Menu");
    }
}