/// FoodSpawn.cs
/// 
/// Generates 3D Particles for characters to pickup and absorb
/// To-Do: Spawn within the gameworld only
///        Currently scripted to spawn within the camera radius
/// 
/// Author: Peter Wolfgang Linder
/// Date: February 27th, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour class script for Spawners to instantiate food in specific coordinates
public class FoodSpawn : MonoBehaviour
{
    public GameObject Food;     // A spherical object that exists only for player consumption
    [SerializeField]
    private float invokingSpeed; // Represents how frequently the Food will instantiate

    // Start is called once, at the beginning
    private void Start()
    {
        Generate();
        InvokeRepeating("Generate", 0, invokingSpeed);  // Repeatedly instantiates food objects for later consumption
    }

    /// <summary>
    /// Generate a vector to instantiate a Food object at its coordinates
    /// 
    /// Generates Vectors on a planet's surface
    /// </summary>
    void Generate()
    {
        // Generates within the camera's view. Should be changed to the dimensions of the world.
        //int x = Random.Range(0, Camera.main.pixelWidth);
        //int y = Random.Range(0, Camera.main.pixelHeight);

        //Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        //Target.z = 0;

        // Random.onUnitSphere generates a random vector on a sphere of radius 1.
        // Useful for generating on top of our planets
        
        Instantiate(Food, Random.onUnitSphere * 12, Quaternion.identity);
    }
}
