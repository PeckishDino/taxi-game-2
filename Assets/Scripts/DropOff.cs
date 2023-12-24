using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class DropOff : MonoBehaviour
{
    public ScoreManager scoreManager;
    PickUp[] pickUp;
    DropOff[] DropOffLocations;
    public Arrow arrow;

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
            scoreManager.UpdateScore(scoreManager.points);
            CarController carController = other.GetComponent<CarController>();
            {
                carController.hasPassenger = false;
                int rand = Random.Range(0, pickUp.Length);
                arrow.transform.position = pickUp[rand].gameObject.transform.position + arrow.positionOffset;
                pickUp[rand].gameObject.SetActive(true);
                gameObject.SetActive(false);
                
            }

        }
    }
}
