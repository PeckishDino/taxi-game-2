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
        currentSpeed = carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / 50f;


        if (currentSpeed == 0)
        {
            carAudio.pitch = minPitch;
        }

        if (currentSpeed > 0)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }
    }
}