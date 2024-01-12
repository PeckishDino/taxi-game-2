using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Intermediate point;
    public GameObject prompt;
    private bool isEPressed = false; // Flag to check if "E" is pressed

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.E)) 
        { isEPressed = false; 
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
        }
        if (isEPressed && other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            gameObject.SetActive(false);
            point.ChooseDropOff();

            CarController carController = other.GetComponent<CarController>();
            if (carController != null)
            {
                carController.hasPassenger = true;
            }

            isEPressed = false; // Reset the flag after executing the logic
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
        }
    }
}