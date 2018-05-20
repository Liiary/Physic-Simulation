using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    public Rigidbody rBody;
    public Car carScript;

    [Header("Suspension")]
    public float springForce;
    public float damperForce;
    public float springConstant;
    public float damperConstant;
    public float restLenght;

    private float previousLenght;
    private float currentLenght;
    private float springVelocitiy;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, restLenght + carScript.wheelRadius))
        {
            previousLenght = currentLenght;
            currentLenght = restLenght - (hit.distance - carScript.wheelRadius);
            springVelocitiy = (currentLenght - previousLenght) / Time.fixedDeltaTime;
            springForce = springConstant * currentLenght;
            damperForce = damperConstant * springVelocitiy;

            rBody.AddForceAtPosition(transform.up * (springForce + damperForce), transform.position);
        }
    }
}
