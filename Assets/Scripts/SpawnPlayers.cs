/// SpawnPlayers.cs
/// 
/// Generates Locations for Players to spawn
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 5th, 2022
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab; // The player prefab to spawn in

    private void Start()
    {
        // To-Do:: Change spawn position to a random planet's orbit
        // PhotonNetwork Instantiate function instantiates players on the server, so that all are visible to each player in the game
        
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, Random.onUnitSphere * 12, Quaternion.identity);
        }
        if (!PhotonNetwork.IsConnected)
        {
            Instantiate(playerPrefab, Random.onUnitSphere * 12, Quaternion.identity);
        }
    }
}
