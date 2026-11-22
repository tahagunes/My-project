using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private const string BestScoreKey = "BestScore";

    private int score = 0;
    private bool isGameOver = false;

    public bool IsGameOver => isGameOver;

    public void AddScore()
    {
        if (isGameOver) return;

        score++;
        scoreText.text = score.ToString();
    }

     public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        int best = PlayerPrefs.GetInt(BestScoreKey, 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt(BestScoreKey, best);
            PlayerPrefs.Save();
        }

        bestScoreText.text = "Best: " + best;
        gameOverPanel.SetActive(true);
    }

      private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
{
    Debug.Log("Restart çağrıldı");
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
}

}