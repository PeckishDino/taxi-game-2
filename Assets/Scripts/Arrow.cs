using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 positionOffset = new Vector3(0, 30, 0);  // Set default offset here or in the Unity Editor.
    public float positionAmplitude = 4.0f;  // The magnitude of the position oscillation.
    public float positionFrequency = 2.0f;  // The speed of the position oscillation.

    public float rotationAmplitude = 180.0f;  // The magnitude of the rotation oscillation (in degrees).
    public float rotationFrequency = 5.0f;  // The speed of the rotation oscillation.

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;  // Store the initial position of the arrow.
        startRotation = transform.rotation;  // Store the initial rotation of the arrow.
    }

    private void Update()
    {
        // Calculate the new Y position based on a sine wave and time.
        float newPositionY = startPosition.y + positionAmplitude * Mathf.Sin(positionFrequency * Time.time);

        // Combine with the position offset.
        Vector3 combinedPosition = new Vector3(transform.position.x, newPositionY, transform.position.z) + positionOffset;

        // Update the arrow's position.
        transform.position = combinedPosition;

        // Calculate the new Y rotation based on a sine wave and time.
        float newYRotation = startRotation.eulerAngles.y + rotationAmplitude * Mathf.Sin(rotationFrequency * Time.time);

        // Combine with the original rotations.
        Quaternion combinedRotation = Quaternion.Euler(startRotation.eulerAngles.x, newYRotation, startRotation.eulerAngles.z);

        // Update the arrow's rotation.
        transform.rotation = combinedRotation;
    }
}
