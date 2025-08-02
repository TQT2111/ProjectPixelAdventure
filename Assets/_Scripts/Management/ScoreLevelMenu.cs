using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreLevelMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreTextLevelOne; // Text hiển thị điểm cao nhất LevelOne
    [SerializeField] private TextMeshProUGUI highScoreTextLevelTwo; // Text hiển thị điểm cao nhất LevelTwo
    [SerializeField] private TextMeshProUGUI highScoreTextLevelBoss; // Text hiển thị điểm cao nhất LevelThree

    void Start()
    {
        // Lấy và hiển thị điểm số cao nhất cho từng level
        highScoreTextLevelOne.text = PlayerPrefs.GetInt("HighScore_LevelOne", 0).ToString();
        highScoreTextLevelTwo.text = PlayerPrefs.GetInt("HighScore_LevelTwo", 0).ToString();
        highScoreTextLevelBoss.text = PlayerPrefs.GetInt("HighScore_LevelBoss", 0).ToString();
    }

    public void ResetHighScores()
    {
        PlayerPrefs.DeleteKey("HighScore_LevelOne");
        PlayerPrefs.DeleteKey("HighScore_LevelTwo");
        PlayerPrefs.DeleteKey("HighScore_LevelBoss");
        PlayerPrefs.Save();
        // Cập nhật lại giao diện
        highScoreTextLevelOne.text = PlayerPrefs.GetInt("HighScore_LevelOne", 0).ToString();
        highScoreTextLevelTwo.text = PlayerPrefs.GetInt("HighScore_LevelTwo", 0).ToString();
        highScoreTextLevelBoss.text = PlayerPrefs.GetInt("HighScore_LevelBoss", 0).ToString();
    }
}
