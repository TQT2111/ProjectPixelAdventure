using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    void Update()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
