using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject prompt;
    DropOff[] dropOff;
    public PickUp[] pickUp;
    private bool isEPressed = false; // Flag to check if "E" is pressed
    public Arrow arrow;
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
        int rand = Random.Range(0, pickUp.Length);
        arrow.transform.position = pickUp[rand].gameObject.transform.position + arrow.positionOffset;
        pickUp[rand].gameObject.SetActive(true);
    }

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
            int rand = Random.Range(0, dropOff.Length);
            arrow.transform.position = dropOff[rand].gameObject.transform.position + arrow.positionOffset;
            dropOff[rand].gameObject.SetActive(true);

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