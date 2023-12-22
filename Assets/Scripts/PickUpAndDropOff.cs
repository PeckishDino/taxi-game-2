using UnityEngine;

public class PickUpAndDropOff : MonoBehaviour
{
    public PickUpAndDropOff pickedUp;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Perform pickup action (e.g., deactivate NPC GameObject)
            CarController carController = other.GetComponent<CarController>();
            if (carController != null)
            {
                if (gameObject.CompareTag("Pick Up"))
                {
                    Debug.Log("Passenger picked up");
                    carController.hasPassenger = true;
                    pickedUp = this;
                    Debug.Log("Current pickedUp: " + pickedUp);
                    pickedUp.gameObject.SetActive(false);
                }
                else if (gameObject.CompareTag("Drop Off"))
                {
                    Debug.Log("Current pickedUp: " + pickedUp);
                    Debug.Log("Passenger dropped off");
                    carController.hasPassenger = false;

                    if (pickedUp != null)
                    {
                        Debug.Log("pickedUp is not null");
                        pickedUp.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("pickedUp is null");
                    }
                }
                                Debug.Log("Current pickedUp: " + pickedUp);
            }
            else
            {
                Debug.Log("NewTaxi component not found!"); // Debug log if NewTaxi component is not found
            }
        }
    }
}