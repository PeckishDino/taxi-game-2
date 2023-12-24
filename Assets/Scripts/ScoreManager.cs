using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;            // Current score
    public TextMeshProUGUI scoreText;           // Reference to the UI Text element
    public int points = 10;

    // Call this method to update the score
    public void UpdateScore(int points)
    {
        score += points;             // Add points to the score
        scoreText.text = "Score: " + score.ToString();  // Update the Text element with the new score
    }
}
