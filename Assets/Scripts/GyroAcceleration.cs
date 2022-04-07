/// GyroAcceleration.cs
/// 
/// Applies Acceleration in a direction corresponding to a phone's pitch (Gyroscope)
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 3rd, 2022
/// 
/// @see: https://answers.unity.com/questions/434096/lock-rotation-of-gyroscope-controlled-camera-to-fo.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroAcceleration : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float rotationSpeed = 3f;
    [SerializeField]
    private float maxSpeed = 9f;   // Prevents constant acceleration

    public Rigidbody rb;           // A rigid body to apply gyroscope controls to

    //private PlayerController player;

    //[SerializeField]
    public float rollDegrees;              // Sideways rotation of a phone

    //[SerializeField]
    public float pitchDegrees;             // Forward/Back rotation of a phone

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        DeviceRotation.Get();
    }

    /// <summary>
    /// Gets the rotation of a device, applies a forward force to it and clamps its maximum speed
    /// </summary>
    private void Accelerate()
    {
        Quaternion deviceRotation = DeviceRotation.Get();

        transform.rotation = deviceRotation;        // To-Do: Only transform by pitchDegrees
        //transform.rotation = new Vector3(0, rotationSpeed * Input.gyro.gravity.x, 0);

        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        //rb.AddForce(transform.up * speed, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    /// <summary>
    /// Returns the rotation angle of given device axis. Use Vector3.right to obtain pitch, Vector3.up for yaw and Vector3.forward for roll.
    /// This is for landscape mode. Up vector is the wide side of the phone and forward vector is where the back camera points to.
    /// </summary>
    /// <returns>A scalar value, representing the rotation amount around specified axis.</returns>
    /// <param name="axis">Should be either Vector3.right, Vector3.up or Vector3.forward. Won't work for anything else.</param>
    float GetAngleByDeviceAxis(Vector3 axis)
    {
        Quaternion deviceRotation = DeviceRotation.Get();
        Quaternion elevationOfOthers = Quaternion.Inverse(
            Quaternion.FromToRotation(axis, deviceRotation * axis)
        );
        Vector3 filteredEuler = (elevationOfOthers* deviceRotation).eulerAngles;

        float result = filteredEuler.z;
        if (axis == Vector3.up)
        {
            result = filteredEuler.y;
        }
        if (axis == Vector3.right)
        {
            // incorporate different euler representations.
            result = (filteredEuler.y > 90 && filteredEuler.y < 270) ? 180 - filteredEuler.x : filteredEuler.x;
        }
        return result;
    }

    public void GetPitchAndRoll()
    {
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

    private void Update()
    {
        Accelerate();

        //GetPitchAndRoll();
    }
}
