using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    [SerializeField] WheelCollider FR, FL, RR, RL; //wheels (Front Right, Left, Rear Right, Left)
    [SerializeField] Transform FRT, FLT, RRT, RLT; //T = Transform
    [SerializeField] private float maxSpeed = 15f;


    public float acceleration = 20000f;
    public float brakingForce = 50000f;
    public float maxTurnAngle = 45f;
    public float brakingFactor = 3000f;


    public float speed;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;



    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        speed = GetComponent<Rigidbody>().velocity.magnitude;

        // Apply braking if the forward key is not being pressed
        if (Input.GetAxis("Vertical") == 0f)
        {
            // Calculate the braking force based on the car's current speed
            float brakeForce = speed * brakingFactor;

            // Apply the braking force to slow down the car
            if (speed > 2f)
            {
                GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity.normalized * brakeForce);
            }
            else
            {
                // If the car's speed is very low, stop the car
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        if (speed > maxSpeed)
        {
            // Calculate the capped velocity
            Vector3 cappedVelocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;

            // Set the car's velocity to the capped value
            GetComponent<Rigidbody>().velocity = cappedVelocity;
        }

        if (Input.GetKey(KeyCode.Space))
            currentBrakeForce = brakingForce;
        else
            currentBrakeForce = 0f;

        FR.motorTorque = currentAcceleration;
        FL.motorTorque = currentAcceleration;

        FR.brakeTorque = currentBrakeForce;
        FL.brakeTorque = currentBrakeForce;
        RR.brakeTorque = currentBrakeForce;
        RL.brakeTorque = currentBrakeForce;


        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        FL.steerAngle = currentTurnAngle;
        FR.steerAngle = currentTurnAngle;

        UpdateWheel(FR, FRT);
        UpdateWheel(FL, FLT);
        UpdateWheel(RR, RRT);
        UpdateWheel(RL, RLT);


    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

}
