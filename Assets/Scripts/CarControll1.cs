using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControll1 : MonoBehaviour
{
    public List<AxleInfo> AxleInfos;
    public float MotorTorque;
    public float SteeringAngle;
    public Transform CenterOfMass;

    private void Update()
    {
        GetComponent<Rigidbody>().centerOfMass = CenterOfMass.localPosition;
    }

    public void FixedUpdate()
    {
        float motor = MotorTorque * Input.GetAxis("Vertical");
        float steering = SteeringAngle * Input.GetAxis("Horizontal");

        foreach(AxleInfo axleInfo in AxleInfos)
        {
            if (axleInfo.Steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.Motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            ApplyPositionToVisuals(axleInfo.leftWheel);
            ApplyPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void ApplyPositionToVisuals(WheelCollider wCollider)
    {
        if(wCollider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = wCollider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        wCollider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
}
