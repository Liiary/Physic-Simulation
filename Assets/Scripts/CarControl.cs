using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarControl : MonoBehaviour
{
    [SerializeField]
    private AxleInfo[] axleInfos;
    [SerializeField]
    private GearInfo[] gearInfos;

    private GearInfo currentGear;

    [SerializeField]
    private float brakeSpeed = 80;
    [SerializeField]
    private Rigidbody rBody;

    private Vector3 visualWheelOffset = Vector3.zero;

    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text gearText;

    public void ControlCar()
    {
        float motor = currentGear.maxMotorTorque * Input.GetAxis("Vertical");
        float steering = currentGear.maySteeringAngle * Input.GetAxis("Horizontal");

        speedText.text = "Speed: " + rBody.velocity.magnitude.ToString();

        if(rBody.velocity.magnitude > currentGear.minimumSpeed)
        {
            motor *= 2;
        }
        else
        {
            motor *= 0.25f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Brake();
            return;
        }

        for(int i = 0; i < axleInfos.Length; i++)
        {
            AxleInfo axleInfo = axleInfos[i];

            if (axleInfo.Steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.Motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.leftWheel.motorTorque = 0;
                axleInfo.rightWheel.motorTorque = motor;
                axleInfo.rightWheel.brakeTorque = 0;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    private void Start()
    {
        //visualWheelOffset = axleInfos[0].leftWheel.transform.GetChild(0).eulerAngles;
    }

    private void Brake()
    {
        for (int i = 0; i < axleInfos.Length; i++)
        {
            AxleInfo axleInfo = axleInfos[i];

            if (axleInfo.Motor)
            {
                axleInfo.leftWheel.motorTorque = 0;
                axleInfo.rightWheel.motorTorque = 0;

                axleInfo.leftWheel.brakeTorque = brakeSpeed;
                axleInfo.rightWheel.brakeTorque = brakeSpeed;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    private void ApplyLocalPositionToVisuals(WheelCollider wheelCollider)
    {
        if (wheelCollider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = wheelCollider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);

        rotation.eulerAngles += visualWheelOffset;

        visualWheel.position = position;
        visualWheel.rotation = rotation;
    }
}

[System.Serializable]
public struct AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool Motor;
    public bool Steering;
}

[System.Serializable]
public struct GearInfo
{
    public float maxMotorTorque;
    public float maySteeringAngle;
    public float minimumSpeed;
}
