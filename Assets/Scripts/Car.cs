using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody rigidbody;

    [Header("Car Specs")]
    public float wheelRadius;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
