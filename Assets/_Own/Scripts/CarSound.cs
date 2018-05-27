using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public GameObject Car;
    public float TopSpeed = 100f;

    private float currentSpeed = 0;
    private float pitch = 0;

    private void Update()
    {
        if (!Timer.finish)
        {
            currentSpeed = Car.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
            pitch = currentSpeed / TopSpeed;

            Car.GetComponent<AudioSource>().pitch = pitch;
        }

        if (Timer.finish || CarController.PauseGame)
        {
            Car.GetComponent<AudioSource>().enabled = false;
        }

        if (!CarController.PauseGame)
        {
            Car.GetComponent<AudioSource>().enabled = true;
        }
    }
}
