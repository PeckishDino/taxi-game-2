using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public CarController coords;
    public GameObject taxi;          // Reference to your taxi GameObject
    public GameObject targetObject;  // The object you want the arrow to point at

    private Vector3 taxiPosition;    // Store the taxi's position
    private void Update()
    {
        taxiPosition = taxi.transform.position;
        // Calculate direction from taxi to the target object
        Vector3 directionToTarget = targetObject.transform.position - taxiPosition;

        // Rotate the arrow to point in the calculated direction and subtract -90° from the X-axis
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Euler(-90, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // Update the arrow's position to be directly above the taxi
        transform.position = taxiPosition + new Vector3(0, 10, 0); // You can adjust the 1 value to set the height above the taxi
    }
}