/// Consume.cs
/// 
/// Allows for the consumption of other objects on collision
/// 
/// Author: Peter Wolfgang Linder
/// Date: March 12th, 2022
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Behaviour script for Objects that can consume food (Players), allowing them to grow off their consumption
public class Consume : MonoBehaviour
{
    [SerializeField]
    private string Tag;      // The Tag name of the collider-enabled object to be consumed
    [SerializeField]
    private float Growth;    // The increase in scale applied to an object after it consumes
    [SerializeField]
    private Text ScoreText;

    int Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)    // If the object colliding has a differing Tag, destroy it and Grow
        {
            transform.localScale += new Vector3(Growth, Growth, Growth);
            Destroy(other.gameObject);

            Score += 1;
            ScoreText.text = "SCORE: " + Score;
        }
    }
}
