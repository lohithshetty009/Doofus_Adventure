using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 3f; // Given default value of speed as 3f
    [SerializeField] float extraGravity = 10f; // Additional gravity force

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock all rotations
        rb.freezeRotation = true;
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
    }
}
