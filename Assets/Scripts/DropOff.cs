using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    PickUp[] pickUp;
    DropOff[] DropOffLocations;


    private void Awake()
    {
        pickUp = FindObjectsOfType<PickUp>();
        DropOffLocations = FindObjectsOfType<DropOff>();
    }
    private void Start()
    {
        foreach (DropOff d in DropOffLocations)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            CarController carController = other.GetComponent<CarController>();
            {
                carController.hasPassenger = false;
                int rand = Random.Range(0, pickUp.Length);
                pickUp[rand].gameObject.SetActive(true);
                gameObject.SetActive(false);
                
            }

        }
    }
}
