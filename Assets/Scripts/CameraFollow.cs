using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // Reference to the cube (Doofus)
    public Vector3 offset;      // Offset to maintain a position relative to the target

    void Start()
    {
        // If no offset is specified, use the current offset
        if (offset == Vector3.zero)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        // Update the camera position based on the target position plus the offset
        transform.position = target.position + offset;

        // Make the camera look at the cube
        transform.LookAt(target);
    }
}
