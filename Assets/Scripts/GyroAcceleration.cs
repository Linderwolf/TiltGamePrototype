/// GyroAcceleration.cs
/// 
/// Applies Acceleration in a direction corresponding to a phone's pitch (Gyroscope)
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 3rd, 2022
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeviceRotation))]
public class GyroAcceleration : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float maxSpeed = 50f;   // Prevents constant acceleration

    private Rigidbody rb;           // A rigid body to apply gyroscope controls to

    [SerializeField]
    float rollDegrees;              // Sideways rotation of a phone

    [SerializeField]
    float pitchDegrees;             // Forward/Back rotation of a phone

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    /// <summary>
    /// Gets the rotation of a device, applies a forward force to it and clamps its maximum speed
    /// </summary>
    private void Accelerate()
    {
        Quaternion deviceRotation = DeviceRotation.Get();

        transform.rotation = deviceRotation;

        rb.AddForce(transform.forward* speed, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void Update()
    {
        //Accelerate();


        // DMGregory's solution - see: https://gamedev.stackexchange.com/questions/176909/tilting-a-game-object-left-right-forward-back-with-gyroscope-regardless-of-play
        // 
        // Get the vector representing global up (away from gravity)
        // within the device's coordinate system.
        Vector3 localDown = Quaternion.Inverse(Input.gyro.attitude) * Vector3.down;

        // Extract our roll rotation - how much gravity points to our left or right.
        rollDegrees = Mathf.Asin(localDown.x) * Mathf.Rad2Deg;

        // Extract our pitch rotation - how much gravity points forward or back.
        pitchDegrees = Mathf.Atan2(localDown.y, localDown.z) * Mathf.Rad2Deg;
    }
}
