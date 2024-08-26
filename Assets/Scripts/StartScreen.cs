using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreenCanvas; // Reference to the Start Screen Canvas

    // This method will be called when the Start button is clicked
    public void StartGame()
    {
        // Start the coroutine to load the scene with a delay
        StartCoroutine(StartGameWithDelay());
    }

    private IEnumerator StartGameWithDelay()
    {
        // Deactivate the start screen canvas
        if (startScreenCanvas != null)
        {
            startScreenCanvas.SetActive(false);
        }

        // Wait for a short duration (e.g., 0.5 seconds)
        yield return new WaitForSeconds(0.5f);

        // Load the main game scene
        SceneManager.LoadScene("SampleScene");
    }
}
