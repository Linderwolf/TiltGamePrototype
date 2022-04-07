/// ConnectToServer.cs
/// Handles connections to the Photon Multiplayer Server
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 5th, 2022
///
/// @see Photon Docs
/// @see Blackthornprod's Unity & Photon Tutorial: https://www.youtube.com/watch?v=93SkbMpWCGo&t=203s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // This will get called whenever we connect to the multiplayer server
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    // Loads the Lobby scene after joining a lobby
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("MultiplayerMenuScene");
    }

    // To-Do?
    public override void OnLeftLobby()
    {
    }
}
