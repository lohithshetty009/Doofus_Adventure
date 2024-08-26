using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IsVisible : MonoBehaviour
{
    public GameObject PulpitPrefab; // Reference to the Pulpit prefab
    public float MinTime = 2.0f;    // Minimum time before pulpit disappears
    public float MaxTime = 5.0f;    // Maximum time before pulpit disappears
    public TextMeshProUGUI timerText;  // Reference to the Text UI element to display the timer

    private float remainingTime;    // Time left before the pulpit disappears

    void Start()
    {
        // Start the coroutine to handle pulpit visibility and spawning
        StartCoroutine(ToggleVisibilityAndSpawnCo());
    }

    IEnumerator ToggleVisibilityAndSpawnCo()
    {
        // Set the random time before the pulpit disappears
        remainingTime = Random.Range(MinTime, MaxTime);

        // Start coroutine to spawn a new pulpit after 2.5 seconds
        StartCoroutine(SpawnNewPulpitCo());

        // Continuously update the timer display
        while (remainingTime > 0)
        {
            // Update the timer text on screen
            if (timerText != null)
            {
                timerText.text = "Fall In: " + remainingTime.ToString("F2");
            }

            // Decrease the remaining time
            remainingTime -= Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Deactivate the current pulpit after the time runs out
        gameObject.SetActive(false);
    }

    IEnumerator SpawnNewPulpitCo()
    {
        // Wait for 2.5 seconds before spawning a new pulpit
        yield return new WaitForSeconds(2.5f);

        // Determine a new position adjacent to the current pulpit
        Vector3 newPosition = transform.position + GetRandomAdjacentPosition();

        // Instantiate a new pulpit at the new position
        Instantiate(PulpitPrefab, newPosition, Quaternion.identity);
    }

    // Method to calculate a random adjacent position
    Vector3 GetRandomAdjacentPosition()
    {
        // Possible directions: right, left, forward, backward
        Vector3[] directions = new Vector3[]
        {
            new Vector3(9, 0, 0),    // Right
            new Vector3(-9, 0, 0),   // Left
            new Vector3(0, 0, 9),    // Forward
            new Vector3(0, 0, -9)    // Backward
        };

        // Select a random direction
        int randomIndex = Random.Range(0, directions.Length);
        return directions[randomIndex];
    }
}
