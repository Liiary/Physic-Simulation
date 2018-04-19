using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Transform cenOfMass;

    [Header("Car Specs")]
    public float wheelRadius;

    private void Update()
    {
        rigidbody.centerOfMass = cenOfMass.localPosition;
    }
}
