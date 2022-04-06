/// AgarioMove.cs
/// 
/// Movement matching the simple "towards the cursor" controls of Agar.io
/// I don't think I'll be using this
/// 
/// Author: Peter Wolfgang Linder
/// Date: February 27th, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarioMove : MonoBehaviour
{
    public float Speed; // Represents how quickly a player is moving. 

    // Update is called once per frame
    void Update()
    {
        Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // Stores the mouse's position as Target coordinates
        Target.z = transform.position.z;
        //Target.x = transform.position.x;

        // Changes position based on Target coordinates, speed and player size.
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime / transform.localScale.x);
    }
}
