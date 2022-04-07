/// DeviceRotation.cs
/// An abstract class to initiate a Gyroscope and ready it for Unity Quaternions
/// 0.0167f = 60Hz
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 3rd, 2022
/// 
/// @see: ...Can't remember...


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeviceRotation
{
    private static bool gyroInitialized = false;

    public static bool HasGyroScope {
        get {
            return SystemInfo.supportsGyroscope;
        }
    }

    public static Quaternion Get()
    {
        if (!gyroInitialized)
        {
            InitGyro();
        }

        return HasGyroScope
            ? ReadGyroscopeRotation()   // If it has a gyroscope, return the Gyroscope's identity
            : Quaternion.identity;      // Otherwise return a new Quaternion.identity
    }

    /// <summary>
    /// Initializes the system's gyroscope at 60Hz, provided the system supports a gyroscope
    /// </summary>
    private static void InitGyro()
    {
        if (HasGyroScope)
        {
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 0.0167f;    // Set the update interval to its highest value (60hz)
        }
        gyroInitialized = true;
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
    }
}
