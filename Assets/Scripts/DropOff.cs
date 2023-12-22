using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{

    public PickUp npcPickUp;
    public void OnTriggerEnter(Collider other)
    {

        npcPickUp.Appear();
        Debug.Log("Trigger entered by: " + other.gameObject.name); // Debug log to trace the colliding GameObject
        // Check if the colliding GameObject is the taxi (tagged as "Player")
        if (other.CompareTag("Player"))
        {
            // Perform pickup action (e.g., deactivate NPC GameObject)



            CarController carController = other.GetComponent<CarController>();
            if (carController != null)
            {
                Debug.Log("Passenger dropped off");
                carController.hasPassenger = false;
            }
            else
            {
                Debug.Log("NewTaxi component not found!"); // Debug log if NewTaxi component is not found
            }

        }
    }
}
