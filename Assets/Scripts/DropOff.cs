using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{

    public PickUp npcPickUp;
    PickUp[] randPickUp;
    public DropOff[] DropOffLocations;

    private void Start()
    {
        randPickUp = FindObjectsOfType<PickUp>();
        DropOffLocations = FindObjectsOfType<DropOff>();
        foreach (DropOff d in DropOffLocations)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {

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
                int rand = Random.Range(0, npcPickUp.pickUp.Length);
                print(npcPickUp.pickUp[rand]);
                print(npcPickUp.pickUp[rand]);
                npcPickUp.pickUp[rand].gameObject.SetActive(true);
                gameObject.SetActive(false);
                
            }
            else
            {
                Debug.Log("NewTaxi component not found!"); // Debug log if NewTaxi component is not found
            }

        }
    }
}
