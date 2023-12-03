using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText; // text element voor het laten zien van de score.
    private int score = 0; // Variable van de score

    private void Start()
    {
        UpdateScoreText(); // roept andere functie aan om de score te updaten van het begin van de level start.
    }

    // Functie score updaten
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Munt toevoegen aan score
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
