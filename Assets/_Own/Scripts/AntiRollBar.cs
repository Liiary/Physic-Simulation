using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    public WheelCollider LWheel;
    public WheelCollider RWheel;
    public Rigidbody RBody;

    private float antiRoll = 1000.0f;
    private float antiRollForce;

    private void FixedUpdate()
    {
        WheelHit hit = new WheelHit();

        float lTravel = 1.0f;
        float rTravel = 1.0f;

        bool hitGroundL = LWheel.GetGroundHit(out hit);
        if (hitGroundL)
        {
            lTravel = (-LWheel.transform.InverseTransformPoint(hit.point).y - LWheel.radius / LWheel.suspensionDistance);
        }

        bool hitGroundR = RWheel.GetGroundHit(out hit);
        if (hitGroundR)
        {
            rTravel = (-RWheel.transform.InverseTransformPoint(hit.point).y - RWheel.radius / RWheel.suspensionDistance);
        }

        antiRollForce = (lTravel - rTravel) * antiRoll;

        if (hitGroundL)
        {
            RBody.AddForceAtPosition(LWheel.transform.up * -antiRollForce, LWheel.transform.position);
        }

        if (hitGroundR)
        {
            RBody.AddForceAtPosition(RWheel.transform.up * -antiRollForce, RWheel.transform.position);
        }
    }
}
