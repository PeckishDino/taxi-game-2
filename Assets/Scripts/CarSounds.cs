using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour
{
    public PauseMenu paused;
    public float minSpeed;
    private float currentSpeed;

    private Rigidbody carRb;
    public AudioSource carAudio;

    public float minPitch;
    private float pitchFromCar;
    private bool accelerating;

    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        carRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        EngineSound();
    }
    void EngineSound()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            accelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            accelerating = false;
        }

        currentSpeed = carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / 50f;

        // Determine the target pitch based on whether accelerating or not
        float targetPitch = accelerating ? minPitch + pitchFromCar : minPitch;

        // Smoothly interpolate between the current pitch and the target pitch
        carAudio.pitch = Mathf.Lerp(carAudio.pitch, targetPitch, pitchChangeSpeed * Time.deltaTime);
    }

    // Add a serialized field to adjust the speed of pitch change in the Inspector
    [SerializeField] private float pitchChangeSpeed = 5.0f;
}