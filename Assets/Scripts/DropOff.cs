using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class DropOff : MonoBehaviour
{
    public Intermediate point;
    public ScoreManager scoreManager;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            scoreManager.UpdateScore(scoreManager.points);
            CarController carController = other.GetComponent<CarController>();
            {
                carController.hasPassenger = false;
                point.ChoosePickUp();
                gameObject.SetActive(false);
                
            }

        }
    }
}
