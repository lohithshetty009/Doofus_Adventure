using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreenCanvas; // Reference to the Start Screen Canvas
    private AudioSource audioSource; // Reference to the AudioSource component
    //public AudioClip startSound; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.loop = true; 
        }
    }
    public void StartGame()
    {
        if (audioSource != null)
        {    Debug.Log("Audio clip and source are set.");

            audioSource.Play();
        }
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
