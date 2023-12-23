using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    DropOff[] dropOff;
    public PickUp[] pickUp;
    private bool isEPressed = false; // Flag to check if "E" is pressed

    void Awake()
    {
        dropOff = FindObjectsOfType<DropOff>();
        pickUp = FindObjectsOfType<PickUp>();
    }

    private void Start()
    {
        foreach (PickUp p in pickUp)
        {
            p.gameObject.SetActive(false);
        }
        int rand1 = Random.Range(0, pickUp.Length);
        pickUp[rand1].gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (isEPressed && other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            int rand = Random.Range(0, dropOff.Length);
            dropOff[rand].gameObject.SetActive(true);

            CarController carController = other.GetComponent<CarController>();
            if (carController != null)
            {
                carController.hasPassenger = true;
            }

            isEPressed = false; // Reset the flag after executing the logic
        }
    }
}