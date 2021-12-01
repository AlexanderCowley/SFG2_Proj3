using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelState : MonoBehaviour
{
    public void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == 3)
            LoadMainMenu();
        else
            SceneManager.LoadScene
                (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu() => SceneManager.LoadScene(0);

    public void RestartGameScene() => SceneManager.LoadScene(1);

    public void GameOverScene() => SceneManager.LoadScene(2);

    public void WinScene() => SceneManager.LoadScene(3);

    public void QuitGame() => Application.Quit();
}