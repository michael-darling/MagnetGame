using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component that displays the score
    private int score;
    private int displayedScore;

    public float scoreUpdateSpeed = 0.05f; // Speed of the score update in seconds

    void Awake()
    {
        // Ensure that there is only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        displayedScore = 0;
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        score += points;
        StartCoroutine(UpdateScoreGradually());
    }

    private IEnumerator UpdateScoreGradually()
    {
        while (displayedScore < score)
        {
            displayedScore++;
            UpdateScoreText();
            yield return new WaitForSeconds(scoreUpdateSpeed);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = displayedScore.ToString();
        }
    }
}