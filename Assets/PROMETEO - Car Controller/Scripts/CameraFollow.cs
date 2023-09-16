using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float followDistance;
    public float followHeight;
    public float lookAtHeight;
    public float damping;

    private Vector3 offset;
    private Transform carTransform;


    private void Start()
    {
        offset = new Vector3(0, followHeight, -followDistance);

    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.Car.CarController)
            carTransform = GameManager.Instance.Car.transform;

        if (!carTransform)
        {
            return;
        }

        Vector3 desiredPosition = carTransform.position + carTransform.TransformDirection(offset);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

        Vector3 lookAtPosition = carTransform.position + Vector3.up * lookAtHeight;
        transform.LookAt(lookAtPosition);

    }

}
