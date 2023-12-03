using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText; // the UI text element for displaying the score.
    private int score = 0; // Variable to store the score.

    private void Start()
    {
        UpdateScoreText(); // Call this function to update the score text initially.
    }

    // Function to update the score text on the UI.
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Function to handle coin collection.
    public void CollectCoin()
    {
        score++; // Increase the score by 1.
        UpdateScoreText(); // Update the score text on the UI.
    }

    public void addscore() {
        score++;
        UpdateScoreText();
    }
}
