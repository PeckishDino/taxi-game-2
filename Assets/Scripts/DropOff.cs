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

        if (other.CompareTag("Player"))
        {
                CarController carController = other.GetComponent<CarController>();
                carController.hasPassenger = false;
                int rand = Random.Range(0, npcPickUp.pickUp.Length);
                npcPickUp.pickUp[rand].gameObject.SetActive(true);
                gameObject.SetActive(false);
        }
    }
}
