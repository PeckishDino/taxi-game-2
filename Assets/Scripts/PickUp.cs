using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    DropOff[] dropOff;
    PickUp[] pickUp;
    void Start()
    {
        // Find the DropOff script in the scene
        dropOff = FindObjectsOfType<DropOff>();
        pickUp = FindObjectsOfType<PickUp>();
        foreach(PickUp p in pickUp)
        {
            gameObject.SetActive(false);
        }
        foreach (DropOff d in dropOff)
        {
            gameObject.SetActive(false);
        }
        int rand1 = Random.Range(0, pickUp.Length);
        print(rand1 + "this");
        pickUp[rand1].gameObject.SetActive(true);

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
            Debug.Log(dropOff[0] + " " + dropOff[1]);
            // Perform pickup action (e.g., deactivate NPC GameObject)
            gameObject.SetActive(false);

            int rand = Random.Range(0, (dropOff.Length));
            print(rand);
            print(dropOff[rand]);
            dropOff[rand].npcPickUp = this;
            dropOff[rand].gameObject.SetActive(true);

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

   /* public void Appear()
    {
        gameObject.SetActive(true);
    }*/
}