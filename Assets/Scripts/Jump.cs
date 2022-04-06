/// Jump.cs
/// 
/// Allows a player to perform a "Jump" action
/// Provided they are on the ground (TO-DO!!!)
/// 
/// Author: Peter Wolfgang Linder
/// Date: March 13th, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool isJumpKeyPressed;  // Flag to determine whether the assigned Jump key was pressed
    private bool isGrounded;        // Flag to determine whether the player is on the ground

    private readonly string Tag = "Planet"; //"GroundingSurface";              // The Tag name of a collider-enabled object

    // Update is called once per frame
    void Update()
    {
        // Check if space was pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpKeyPressed = true;
        }
    }
    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        if (isJumpKeyPressed)
        {
            //isGrounded = true;         // Temporary fix that enables infinite jumping - Remove when collision is fixed

            isJumpKeyPressed = false;
            if (isGrounded)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);  // Adds a vertical force impulse if the Jump button was pressed
                isGrounded = false;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)    // If the object colliding has a differing Tag, destroy it and Grow
        {
            isGrounded = true;
        }
    }
}
