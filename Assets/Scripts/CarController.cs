using UnityEngine;
using System;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    // Enumeration for control modes (Keyboard or Buttons)
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    // Enumeration for wheel axles (Front or Rear)
    public enum Axel
    {
        Front,
        Rear
    }

    // Structure to define wheel properties
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;          // Reference to the wheel model GameObject
        public WheelCollider wheelCollider;    // Reference to the WheelCollider component
        public GameObject wheelEffectObj;      // Reference to the wheel effect GameObject
        public ParticleSystem smokeParticle;   // Reference to the smoke particle system
        public Axel axel;                      // Axle type (Front or Rear)
    }

    public ControlMode control;                // Control mode for the car (Keyboard or Buttons)

    // Car movement parameters
    public float maxAcceleration = 30.0f;     // Maximum acceleration value
    public float brakeAcceleration = 50.0f;   // Brake acceleration value

    // Steering parameters
    public float turnSensitivity = 1.0f;      // Steering sensitivity
    public float maxSteerAngle = 30.0f;       // Maximum steering angle

    public float maxSpeed = 20f;              // Maximum speed for the car

    public Vector3 _centerOfMass;             // Center of mass for the car

    public List<Wheel> wheels;                // List of wheels attached to the car

    public bool hasPassenger = false;

    private float moveInput;                  // Input for movement (forward/backward)
    private float steerInput;                 // Input for steering (left/right)

    private Rigidbody carRb;                  // Reference to the Rigidbody component of the car


    void Start()
    {
        // Initialize the Rigidbody component and set the center of mass
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        // Get inputs for movement and steering
        GetInputs();

        // Animate wheels and update wheel effects
        AnimateWheels();
        //WheelEffects();
    }

    void LateUpdate()
    {
        // Apply movement, steering, and braking
        Move();
        Steer();
        Brake();
    }

    // Method to set movement input
    public void MoveInput(float input)
    {
        moveInput = input;
    }

    // Method to set steering input
    public void SteerInput(float input)
    {
        steerInput = input;
    }

    // Method to get inputs based on the control mode
    void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
    }

    // Method to handle car movement
    void Move()
    {
        // Calculate the current speed of the car
        float currentSpeed = carRb.velocity.magnitude;

        // Check if the current speed exceeds the desired speed cap
        if (currentSpeed > maxSpeed)
        {
            // Calculate the ratio to scale down the motor torque
            float speedRatio = maxSpeed / currentSpeed;

            // Scale down the motor torque to limit the speed
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * speedRatio * Time.deltaTime;
            }
        }
        else
        {
            // Apply the motor torque without any speed limitation
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
            }
        }
    }

    // Method to handle steering
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                // Calculate the steer angle based on the input and sensitivity
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;

                // Apply the steer angle to the front wheels with smoothing
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    // Method to handle braking
    void Brake()
    {
        // Check the sign of the car's forward velocity
        float forwardVelocity = Vector3.Dot(carRb.velocity, transform.forward);

        if ((forwardVelocity > 0 && Input.GetKey(KeyCode.S)) ||  // Car is moving forward and brake key (S) is pressed
            (forwardVelocity < 0 && Input.GetKey(KeyCode.W)))    // Car is moving backward and accelerator key (W) is pressed
        {
            // Apply high brake torque
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 1000 * brakeAcceleration * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.Space) || moveInput == 0)
        {
            // Apply normal brake torque when the space key is pressed or no movement input is detected
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            // Release the brake torque when movement input is detected
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    // Method to animate wheels based on the WheelCollider's pose
    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;

            // Get the world pose of the WheelCollider
            wheel.wheelCollider.GetWorldPose(out pos, out rot);

            // Update the position and rotation of the wheel model
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    // Method to update wheel effects (e.g., trail renderer and smoke particles)
    /*void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            // Check if the space key is pressed and the wheel is grounded with sufficient velocity
            if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
            {
                // Enable the trail renderer and emit smoke particles
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                wheel.smokeParticle.Emit(1);
            }
            else
            {
                // Disable the trail renderer
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }*/
}
