using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Reference to the Text UI element to display the score
    private static int score = 0;      // Static Score to track Pulpits visited

    void Start()
    {
        UpdateScore();  // Initialize the score display
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object Doofus collided with has a tag "Pulpit"
        if (collision.gameObject.CompareTag("Player"))
        {
            score++; // Increment the score
            UpdateScore(); // Update the score on the UI
        }
    }

    // Method to update the score text on the UI
    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Method to reset the score
    public static void ResetScore()
    {
        score = 0;
    }
}
