// FauxGravityAttractor.cs
// A script to cause objects such as planets to attract other objects with simulated gravity
// Adapted from Source Code by Sebastion Lague's 2016 Spherical-Gravity tutorial

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public GravityAttractor planet;      // A reference to a gravitational attractor

    public float gravity = -9.8f;


    public void Attract(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;

        // Apply downwards gravity to body
        body.AddForce(gravityUp * gravity);

        // Allign bodies up axis with the centre of planet
        body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }

}