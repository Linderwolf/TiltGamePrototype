/// CreateAndJoinRooms.cs
/// 
/// @see Blackthornprod's Unity & Photon Tutorial: https://www.youtube.com/watch?v=93SkbMpWCGo&t=203s


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

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
    /// Photon Callback Function
    /// Loads the Main Game Scene when a player joins a room
    /// </summary>
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGameScene");
    }
}
