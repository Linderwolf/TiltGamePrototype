// GravityOrbit.cs
// Sets the gravitational body that objects will orbit on entry
// See Slug Glove's Mario Galaxy Gravity Tutorial - https://www.youtube.com/watch?v=aZOyZJhreSU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float gravity;

    private void OnTriggerEnter(Collider other)
    {
        // If an entering object is affected by gravity, set this planet's gravity as the active gravitational orbit
        other.GetComponent<GravityControl>().gravityOrbit = this.GetComponent<GravityOrbit>();
    }
}
