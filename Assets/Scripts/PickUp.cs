using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Static flag to ensure Awake() logic runs only once

    DropOff[] dropOff;
    public PickUp[] pickUp;

    void Awake()
    {
        // Check if the initialization has already occurred

        // Mark the script as initialized

        // Find the DropOff script in the scene
        dropOff = FindObjectsOfType<DropOff>();
        pickUp = FindObjectsOfType<PickUp>();

        // Debug logs for troubleshooting
        Debug.Log("Number of Pick Up Locations: " + pickUp.Length);
        /*foreach (PickUp p in pickUp)
        {
            Debug.Log("Found PickUp: " + p.gameObject.name);
            p.gameObject.SetActive(false);
        }

        Debug.Log("Number of Drop Off Locations: " + dropOff.Length);
        foreach (DropOff d in dropOff)
        {
            Debug.Log("Found DropOff: " + d.gameObject.name);
        }

        // Randomly activate one PickUp GameObject
        int rand1 = Random.Range(0, pickUp.Length);
        pickUp[rand1].gameObject.SetActive(true);

        if (dropOff == null)
        {
            Debug.LogError("DropOff script not found in the scene!"); // Log an error if DropOff script is not found
        }*/
    }
    private void Start()
    {
        foreach (PickUp p in pickUp)
        {
            Debug.Log("Found PickUp: " + p.gameObject.name);
            p.gameObject.SetActive(false);
        }
        foreach (DropOff d in dropOff)
        {
            Debug.Log("Found DropOff: " + d.gameObject.name);
        }
        int rand1 = Random.Range(0, pickUp.Length);
        pickUp[rand1].gameObject.SetActive(true);

        if (dropOff == null)
        {
            Debug.LogError("DropOff script not found in the scene!"); // Log an error if DropOff script is not found
        }
    }

public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); // Debug log to trace the colliding GameObject

        if (other.CompareTag("Player"))
            dropOff = FindObjectsOfType<DropOff>();
        print(dropOff);
        {
          //  Debug.Log(dropOff[0] + " " + dropOff[1]);

            // Deactivate the current PickUp GameObject
            gameObject.SetActive(false);

            // Randomly select and activate one DropOff GameObject
            int rand = Random.Range(0, dropOff.Length);
            print(rand);
            print("Number of Drop Off Locations: " + dropOff.Length);
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
