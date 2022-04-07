/// Consume.cs
/// 
/// Allows for the consumption of other objects on collision
/// 
/// Issues: Photon only allows destruction of objects that were created be a playerview
/// meaning you cannot simply consume others' instantiated objects...
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
    private string playerTag = "Player";  // The Tag name of a collider-enabled player object to be consumed
    private string foodTag = "Food";      // The Tag name of a collider-enabled food object to be consumed

    [SerializeField]
    private float Growth;     // The increase in scale applied to an object after it consumes
    [SerializeField]
    private Text ScoreText;

    public float Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == foodTag)    // If the object colliding has a differing Tag, destroy it and Grow
        {
            transform.localScale += new Vector3(Growth, Growth, Growth);
            Destroy(other.gameObject);

            Score += Growth;
            ScoreText.text = "SCORE: " + Score * 20;
        }

        if (other.gameObject.tag == playerTag)
        {
            // Get the other player's consume class instance
            Consume playerToConsume = other.gameObject.GetComponent<Consume>();
            float otherScore = playerToConsume.Score;

            // If your score is greater than the other player's
            if (Score > playerToConsume.Score)
            {
                otherScore += .1f;

                transform.localScale += new Vector3(otherScore, otherScore, otherScore);
                Destroy(other.gameObject);

                Score += otherScore;
                ScoreText.text = "SCORE: " + Score * 10;
            }
        }
    }
}
