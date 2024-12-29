using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highestScoreText;

    private int currentScore = 0;  // Điểm mặc định là 0
    private int highestScore = 0;  // Điểm cao nhất mặc định là 0

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            UpdateUI(); // Cập nhật UI khi khởi tạo
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetScore(); // Reset điểm khi bắt đầu
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
        }
        UpdateUI();
        Debug.Log($"Score updated - Current: {currentScore}, Highest: {highestScore}");
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
        Debug.Log("Score reset to 0");
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }

        if (highestScoreText != null)
        {
            highestScoreText.text = $"Highest Score: {highestScore}";
        }
    }

    public int GetCurrentScore() => currentScore;
    public int GetHighestScore() => highestScore;
}