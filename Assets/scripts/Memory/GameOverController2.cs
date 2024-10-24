using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController2 : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Precision");
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("Menu");
    }
}