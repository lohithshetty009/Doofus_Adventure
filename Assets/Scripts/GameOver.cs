using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // Required for IEnumerator

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;  // Reference to the Text UI element to display "Game Over"
    public Transform doofus;              // Reference to the Doofus cube

    private bool isGameOver = false;

    void Update()
    {
        // Check if Doofus falls below a certain height
        if (doofus.position.y < 1f && !isGameOver)
        {
            GameOver();
        }
    }

    // Method to handle the game over state
    void GameOver()
    {
        isGameOver = true;
        gameOverText.text = "Wasted";  // Display "Game Over" message
        StartCoroutine(RestartGameAfterDelay(2f));  // Start coroutine to restart the game after 2 seconds
    }

    // Coroutine to restart the game after a delay
    IEnumerator RestartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }
}
