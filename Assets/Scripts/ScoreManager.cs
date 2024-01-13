using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;           // Current score
    public TextMeshProUGUI scoreText;  // Reference to the UI Text element
    public int points = 10;
    private float startTime;
    public float elapsedTime;
    private float gameTime;
    private float gameTimeStart;
    public float wallet;
    public float fare;
    public TextMeshProUGUI fareText;
    public TextMeshProUGUI walletText;
    public TextMeshProUGUI fuelText;

    public CarController fuel;

    // Call this method to update the score
    public void UpdateScore(int points)
    {
        score += points;  // Add points to the score
        scoreText.text = "Score: " + score.ToString();  // Update the Text element with the new score
    }

    private void Start()
    {
        gameTimeStart = Time.time;
        fare = 0;
    }

    private void Update()
    {
        GameTime();
        DecreaseFareOverTime();  // Decrease fare over time
        fareText.text = "Fare: £" + RoundToTwoDecimalPlaces(fare).ToString();
        walletText.text = "Wallet: £" + RoundToTwoDecimalPlaces(wallet).ToString();
        fuelText.text = "Fuel: " + Mathf.Round((fuel.fuelTank/50)*100) + "%";
    }

    public void GameTime()
    {
        gameTime = Time.time - gameTimeStart;
    }

    public void ToggleTimer()
    {
        if (startTime == 0)  // Timer is not started
        {
            GenerateRandomFare();
            startTime = Time.time;  // Start the timer
            Debug.Log("Timer Started");
        }
        else  // Timer is already started
        {
            elapsedTime = Time.time - startTime;  // Calculate the elapsed time
            Debug.Log("Elapsed Time: " + elapsedTime.ToString("F2") + " seconds");  // Log the elapsed time

            // Add the final fare to the wallet
            wallet += RoundToTwoDecimalPlaces(fare);
            

            // Reset the fare
            fare = 0;

            // Reset the timer
            startTime = 0;
            elapsedTime = 0;
            Debug.Log("Timer Reset");
        }
    }

    private void GenerateRandomFare()
    {
        // Generate a random fare rounded to two decimal places
        fare = RoundToTwoDecimalPlaces(Random.Range(3.0f, 8.0f));
    }

    private void DecreaseFareOverTime()
    {
        // Decrease the fare over time (adjust the rate as needed)
        fare -= Time.deltaTime / 15.0f;
        fare = Mathf.Max(fare, 0.0f);  // Ensure fare doesn't go below zero
    }

    private float RoundToTwoDecimalPlaces(float number)
    {
        return Mathf.Round(number * 100.0f) / 100.0f;
    }
}
