/// GravityControl.cs
/// Causes Rigidbodies to be affected by the planets' gravitational orbits
///
/// Author: Peter Wolfgang Linder
/// Date: April 5th, 2022
///
/// @see Slug Glove's Mario Galaxy Gravity Tutorial - https://www.youtube.com/watch?v=aZOyZJhreSU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public GravityOrbit gravityOrbit;   // References the Gravity object we're orbiting around
    private Rigidbody rigidBody;        // The gravity-affected body

    public float RotationSpeed = 2;     // How quick the adjustment to the new gravity occurs

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gravityOrbit)    // If there is a set planet to orbit
        {
            Vector3 gravityUp = Vector3.zero;   // Represents the upward direction from the planet's centre
            gravityUp = (transform.position - gravityOrbit.transform.position).normalized;

            Vector3 localUp = transform.up;     // Represents the upward direction of a character

            transform.up = Vector3.Lerp(localUp, gravityUp, RotationSpeed * Time.deltaTime);  // Change player orientation

            rigidBody.AddForce((-gravityUp * gravityOrbit.gravity) * rigidBody.mass);         // Pull a body down
        }
    }
}
