using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button quitButton;

    private bool isPaused = false;

    private void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(QuitToMainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

public void Resume()
{
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;

    // Hide the cursor and lock it
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
}

public void Pause()
{
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;

    // Show the cursor and unlock it
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
}
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // replace "MainMenu" with the name of your main menu scene
    }
}