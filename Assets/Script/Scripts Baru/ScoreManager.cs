using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    [Header("UI")]
    public TextMeshProUGUI scoreText;   // UI score kanan atas
    public TextMeshProUGUI finalScoreText; // UI score saat Game Over

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void ShowFinalScore()
    {
        if (finalScoreText != null)
            finalScoreText.text = "FINAL SCORE : " + score;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score : " + score;
    }
}
