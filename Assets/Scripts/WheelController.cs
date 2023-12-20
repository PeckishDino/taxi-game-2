using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider FR, FL, RR, RL; //wheels (Front Right, Left, Rear Right, Left)
    [SerializeField] Transform FRT, FLT, RRT, RLT; //T = Transform
    [SerializeField] private float maxSpeed = 5000f;


    public float acceleration = 1000f;
    public float brakingForce = 20000f;
    public float maxTurnAngle = 15f;

    public float speed;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        speed = GetComponent<Rigidbody>().velocity.magnitude;
        if (speed >= maxSpeed)
        {
            currentAcceleration = 0f;
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
