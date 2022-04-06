using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroAcceleration : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float maxSpeed = 50f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        Quaternion deviceRotation = DeviceRotation.Get();

        transform.rotation = deviceRotation;

        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

    }
}
