/// CreateAndJoinRooms.cs
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 5th, 2022
/// 
/// @see Blackthornprod's Unity & Photon Tutorial: https://www.youtube.com/watch?v=93SkbMpWCGo&t=203s


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    private LoadBalancingClient loadBalancingClient;

    /// <summary>
    /// Creates a Photon Multiplayer Session with a given room name
    /// </summary>
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    /// <summary>
    /// Joins a Photon Multiplayer Session with the corresponding room code
    /// </summary>
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    /// <summary>
    /// Joins a Random available room, or creates one, if none are available
    /// </summary>
    private void QuickMatch()
    {
        loadBalancingClient.OpJoinRandomOrCreateRoom(null, null); ;
    }

    /// <summary>
    /// Photon Callback Function
    /// Loads the Main Game Scene when a player joins a room
    /// </summary>
    public override void OnJoinedRoom()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("MainGameScene");
        PhotonNetwork.IsMessageQueueRunning = false;
    }
}
