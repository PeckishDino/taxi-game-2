using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class fuelUp : MonoBehaviour
{
    public CarController tankFill;
    public ScoreManager payment;
    public FuelPrice cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool isFPressed = false; // Flag to check if "F" is pressed

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            isFPressed = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (isFPressed && other.CompareTag("Player"))
        {
            if ((tankFill.fuelTank + 0.1f) > 50 || payment.wallet - (cost.fuelPrice / 10) < 0)
            {

                print("Your tank is full or you are out of money");
                
            }
            else
            {
                print("fueling up");
                tankFill.fuelTank += 0.1f;
                payment.wallet -= (cost.fuelPrice) / 10;
            }
        }
    }
}
