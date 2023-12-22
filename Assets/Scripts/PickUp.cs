using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    DropOff dropOff;
    void Start()
    {
        // Find the DropOff script in the scene
        dropOff = FindObjectOfType<DropOff>();

        if (dropOff == null)
        {
            Debug.LogError("DropOff script not found in the scene!"); // Log an error if DropOff script is not found
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); // Debug log to trace the colliding GameObject
        // Check if the colliding GameObject is the taxi (tagged as "Player")
        if (other.CompareTag("Player"))
        {
            // Perform pickup action (e.g., deactivate NPC GameObject)
            gameObject.SetActive(false);

            dropOff.npcPickUp = this;

            CarController carController = other.GetComponent<CarController>();
            if (carController != null)
            {
                Debug.Log("Passenger picked up");
                carController.hasPassenger = true;
            }
            else
            {
                Debug.Log("NewTaxi component not found!"); // Debug log if NewTaxi component is not found
            }

        }
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }
}