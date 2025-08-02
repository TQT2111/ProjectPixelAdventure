using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI loseScoreText;
    [SerializeField] private TextMeshProUGUI winnerScoreText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private string currentLevel;
    private bool isGameOver = false;
    private int highScore;
    void Start()
    {
        SetScore();
        UpdateScore();
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
    }
    private void Update()
    {
        PauseGame();
    }
    private void SetScore()
    {
        currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        highScore = PlayerPrefs.GetInt("HighScore_" + currentLevel, 0);
        score = 0;
    }
    public void AddScore(int points)
    {
        if (!isGameOver) {
            score += points;
            UpdateScore();
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore_" + currentLevel, highScore);
                PlayerPrefs.Save();
            }
        }
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
        loseScoreText.text = score.ToString();
        winnerScoreText.text = score.ToString();
    }
    public void GameOver()
    {
            isGameOver = true;
            score = 0;
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    private void PauseGame()
    {
        bool InputPause = InputManager.Instance.GetInputPause;
        if (InputPause && isGameOver == false)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ClosePauseGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    public int GetHighScore()
    {
        return highScore;
    }
}
