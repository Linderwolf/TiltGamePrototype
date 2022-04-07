/// SpawnFood.cs
/// 
/// Generates Locations for Players to spawn
/// 
/// Generates 3D Particles for characters to pickup and absorb
/// 
/// Author: Peter Wolfgang Linder
/// Date: February 27th, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Behaviour class script for Spawners to instantiate food in specific coordinates
public class SpawnFood : MonoBehaviour
{
    public GameObject Food;      // A spherical object that exists only for player consumption
    public int planetDiameter;   // An approximate length of a planet, for generating spawning locations

    [SerializeField]
    private float invokingSpeed; // Represents how frequently the Food will instantiate

    // Start is called once, at the beginning
    private void Start()
    {
        InvokeRepeating("FreeFoodGeneration", 0, invokingSpeed);  // Repeatedly instantiates food objects for later consumption
    }

    /// <summary>
    /// Generate a vector to instantiate a Food object at its coordinates
    /// 
    /// Generates Vectors on a planet's surface
    /// </summary>
    void FreeFoodGeneration()
    {
        // Random.onUnitSphere generates a random vector on a sphere of radius 1.
        // Useful for generating on top of our planets

        Instantiate(Food, RandomizePlanet() + Random.onUnitSphere * planetDiameter, Quaternion.identity);
    }

    /// <summary>
    /// Generate a vector to instantiate a Photon Network Food object at its coordinates
    /// 
    /// Generates Vectors on a planet's surface
    /// 
    /// Issues:: Photon allows only the destruction of objects instantiated by the local playerview
    /// </summary>
    void MultiplayerFoodGeneration()
    {
        PhotonNetwork.InstantiateRoomObject(Food.name, RandomizePlanet() + Random.onUnitSphere * planetDiameter, Quaternion.identity);
    }

    Vector3 RandomizePlanet()
    {
        Vector3 planetLocation = new Vector3(0f, 0f, 0f);
        switch (Random.Range(1, 6))
        {   // Just hardcoding these planet locations for performance sake
            case 1: // Beach Planet
                planetDiameter = 14;
                planetLocation = new Vector3(2.3f, -23.88f, -16.85f);
                return planetLocation;
            case 2: // Forest Planet
                planetDiameter = 14;
                planetLocation = new Vector3(-21.72f, 3.41f, -19.24f);
                return planetLocation;
            case 3: // Green Ice Planet
                planetDiameter = 10;
                planetLocation = new Vector3(11.16f, -13.79f, 13.72f);
                return planetLocation;
            case 4: // Ice Planet
                planetDiameter = 10;
                planetLocation = new Vector3(10.39f, 9.29f, 20.58f);
                return planetLocation;
            case 5: // Orange Planet
                planetDiameter = 12;
                planetLocation = new Vector3(0f, 0f, 0f);
                return planetLocation;
            case 6: // Pine Planet
                planetDiameter = 12;
                planetLocation = new Vector3(-9.7f, 13.32f, 22.02f);
                return planetLocation;
        }
        return planetLocation;
    }
}
