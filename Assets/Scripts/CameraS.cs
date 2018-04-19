using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraS : MonoBehaviour
{
    public Vector3 cameraTransform;
    public Transform carRigidbody;
    public Transform carTransform;
    public float distanceFromCar;
    public float heightFromCar;
    public float rotationDamping;
    public float heightDamping;
    public float zoomRatio;
    public float defaultFOV;

    private Vector3 rotationVector;

    private void LateUpdate()
    {
        float wantedAngle = carTransform.eulerAngles.y;
        float wantedHeight = carTransform.position.y + heightFromCar;
        float cameraAngle = this.transform.eulerAngles.y;
        float cameraHeight = this.transform.position.y;

        cameraAngle = Mathf.LerpAngle(cameraAngle, wantedAngle, rotationDamping * Time.deltaTime);
        cameraHeight = Mathf.Lerp(cameraHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, cameraAngle, 0);

        cameraTransform = carTransform.position;
        cameraTransform -= currentRotation * Vector3.forward * distanceFromCar;
        cameraTransform.y = cameraHeight;
        transform.position = new Vector3(cameraTransform.x, cameraTransform.y, cameraTransform.z);
        this.transform.LookAt(carTransform);
    }

    private void FixedUpdate()
    {
        float speed = carRigidbody.GetComponent<Rigidbody>().velocity.magnitude;
        this.GetComponent<Camera>().fieldOfView = defaultFOV * speed * zoomRatio * Time.deltaTime;
    }
}
