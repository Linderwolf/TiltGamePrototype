/// ConnectToServer.cs
/// Handles connections to the Photon Multiplayer Server
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

    public override void OnJoinedLobby()
    {
        // Note: You don't yet have a Lobby scene
        // Loads the Lobby scene after joining a lobby
        // 
        SceneManager.LoadScene("MainMenuScene");
        GameObject.Find("MainMenu").SetActive(false);
        GameObject.Find("OptionsMenu").SetActive(false);
        GameObject.Find("MultiplayerMenu").SetActive(true);
    }
}
