using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;            // Current score
    public TextMeshProUGUI scoreText;           // Reference to the UI Text element
    public int points = 10;
    private float startTime;
    public float elapsedTime;
    private float gameTime;
    private float gameTimeStart;

    // Call this method to update the score
    public void UpdateScore(int points)
    {
        score += points;             // Add points to the score
        scoreText.text = "Score: " + score.ToString();  // Update the Text element with the new score
    }
    private void Start()
    {
        gameTimeStart = Time.time;
    }

    private void Update()
    {
        GameTime();
    }
    public void GameTime()
    {

        gameTime = Time.time - gameTimeStart;
    }

    public void ToggleTimer()
    {
        if (startTime == 0)  // Timer is not started
        {
            startTime = Time.time;  // Start the timer
            Debug.Log("Timer Started");
        }
        else  // Timer is already started
        {
            elapsedTime = Time.time - startTime;  // Calculate the elapsed time
            Debug.Log("Elapsed Time: " + elapsedTime.ToString("F2") + " seconds");  // Log the elapsed time

            // Reset the timer
            startTime = 0;
            elapsedTime = 0;
            Debug.Log("Timer Reset");
        }
    }
}
