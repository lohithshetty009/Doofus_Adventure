using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 3f; // Given default value of speed as 3f
    [SerializeField] private float extraGravity = 10f; // Additional gravity force

    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock all rotations
        rb.freezeRotation = true;

        // Get the AudioSource component attached to the player
        audioSource = GetComponent<AudioSource>();

        // Optional: Set the audio to loop if it's a continuous sound like footsteps
        if (audioSource != null)
        {
            audioSource.loop = true; // Enable looping for continuous movement sound
        }
    }

    void FixedUpdate()
    {
        // Get movement inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed;

        // Apply movement to the Rigidbody
        rb.velocity = movement;

        // Apply additional gravity force
        rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);

        // Ensure no rotation
        rb.angularVelocity = Vector3.zero;

        // Check if the player is moving
        if (movement.magnitude > 0)
        {
            // Play movement sound if not already playing
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop movement sound if player is not moving
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
