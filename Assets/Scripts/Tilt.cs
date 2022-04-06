/// Tilt.cs
/// 
/// Applies the logic behind the rotation of a gameworld platform
/// 
/// Author: Peter Wolfgang Linder
/// Date: February 20th, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour script for tiltable platform objects
public class Tilt : MonoBehaviour
{
    private Transform tiltTransform;    // The object's transformation properties
    private Vector3 currentRotation;    // The angle of the object's rotation

    // private float horizontalAxisInput;  // The player's directional input on the horizontal axis
    // private float verticalAxisInput;    // The player's vertical input on the horizontal axis
    
    private int rotationMaximum = 350;  // The largest angle a platform can be rotated (Prevents flipping)
    private int rotationMinimum = 8;    // The smallest angle a platform can be rotated (Prevents flipping)

    private Gyroscope gyroscopeInput;   // The active Gyroscope
    private bool isGyroEnabled;         // Determines whether there is a gyroscope for input

    private Quaternion gyroRotation;


    // Awake runs before the first Start call
    private void Awake()
    {
        // I think this is best-practice
        tiltTransform = transform;
        isGyroEnabled = EnableGyro();
        
        // This will not work - The Axis needs to be checked on every frame
        // horizontalAxisInput = Input.GetAxis("Horizontal");
        // verticalAxisInput = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {

        // Gets the platform object's angle of rotation at this frame
        currentRotation = tiltTransform.eulerAngles;    // instead of: GetComponent<Transform>().eulerAngles;

        // If left, rotate left
        if ((Input.GetAxis("Horizontal") < -.1) && (currentRotation.z <= rotationMinimum || currentRotation.z >= rotationMaximum))
        {
            transform.Rotate(0, 0, 10 * Time.deltaTime, Space.World);
        }

        // If right, rotate right
        if ((Input.GetAxis("Horizontal") > .1) && (currentRotation.z >= rotationMaximum+1 || currentRotation.z <= rotationMinimum+1))
        {
            transform.Rotate(0, 0, -10 * Time.deltaTime, Space.World);
        }

        // If up, rotate forwards
        if ((Input.GetAxis("Vertical") > .1) && (currentRotation.x <= rotationMinimum || currentRotation.x >= rotationMaximum))
        {
            transform.Rotate(10 * Time.deltaTime, 0, 0);
        }

        // If down, rotate down
        if ((Input.GetAxis("Vertical") < -.1) && (currentRotation.x >= rotationMaximum + 1 || currentRotation.x <= rotationMinimum + 1))
        {
            transform.Rotate(-10 * Time.deltaTime, 0, 0);
        }

        if (isGyroEnabled)
        {
            transform.localRotation = gyroscopeInput.attitude * gyroRotation;
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscopeInput = Input.gyro;
            gyroscopeInput.enabled = true;

            transform.localRotation = Quaternion.Euler(90f, 90f, 0f);
            gyroRotation = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }
}
