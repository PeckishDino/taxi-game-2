using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    DropOff[] dropOff;
    public PickUp[] pickUp;

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

public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                int rand = Random.Range(0, dropOff.Length);
                dropOff[rand].npcPickUp = this;
                dropOff[rand].gameObject.SetActive(true);

                CarController carController = other.GetComponent<CarController>();
                   carController.hasPassenger = true;
            }
        }
}
