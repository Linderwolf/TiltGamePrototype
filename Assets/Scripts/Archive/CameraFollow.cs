/// CameraFollow.cs
/// 
/// Sets the camera to smoothly follow the player as they move
/// This was initially attempted via Linear Interpolation
/// The SmoothDamp function is a better solution
/// 
/// Author: Peter Wolfgang Linder
/// Date: March 4th, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour script for camera objects to smoothly follow a target
public class CameraFollow : MonoBehaviour
{
    public Transform target;                       // The object the camera will follow (A PlayerSphere, most likely)

    public float smoothTime = 0.3F;                // Approximate time for the camera to reach the target. (Smaller times = faster)
    public Vector3 currentVelocity = Vector3.zero; // The current velocity of the camera
    public Vector3 offset;                         // How far away from the character the camera should be.
    //public float smoothSpeed = 9.25F;            // Needed for Linear Interpolation. This can be removed for SmoothDamp

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;

        // Gradually changes the camera vector towards a target position over time.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        // The below is outdated:
        // Note: Linear Interpolation should not be used on objects in motion. refer to SmoothDamp function docs: https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); // Linear Interpolation
        // transform.LookAt(target); // Not needed for SmoothDamp
    }
}
