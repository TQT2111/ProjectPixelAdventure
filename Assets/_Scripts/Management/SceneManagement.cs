using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void PlayLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
        Time.timeScale = 1;
    }
    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
        Time.timeScale = 1;
    }
    public void PlayLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
        Time.timeScale = 1;
    }
    public void PlayLevelFour()
    {
        SceneManager.LoadScene("MainLevelFour");
        Time.timeScale = 1;
    }
    public void PlayLevelBoss()
    {
        SceneManager.LoadScene("LevelBoss");
        Time.timeScale = 1;
    }
    public void PlayScene()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _ = currentSceneIndex + 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
