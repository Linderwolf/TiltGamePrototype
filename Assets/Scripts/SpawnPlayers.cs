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
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(), Quaternion.identity);
    }
}
