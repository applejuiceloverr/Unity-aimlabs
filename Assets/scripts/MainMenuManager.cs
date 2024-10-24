using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadGameMode(string gameModeSceneName)
    {
        SceneManager.LoadScene(gameModeSceneName);
    }
}
