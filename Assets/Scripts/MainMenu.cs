/// MainMenu.cs
/// 
/// Holds the functions required for Main Menu Navigation
/// 
/// Author: Peter Wolfgang Linder
/// Date: April 4th, 2022
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviour
{
    public GameObject Player;   // A spherical object that a player controls

    /// <summary>
    /// Opens the Main Game Scene for Freeplay
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    /// <summary>
    /// Opens the Main Menu Scene and Disconnects from any Multiplayer Sessions
    /// </summary>
    public void OpenMainMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void StartMultiplayer()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    /// <summary>
    /// Opens the Main Menu Scene
    /// </summary>
    public void OpenMultiplayerMenu()
    {
        SceneManager.LoadScene("MultiplayerMenuScene");
    }

    /// <summary>
    /// Exits the application
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("QuitGame fired - the game would quit outside of the Unity emulator");
        Application.Quit();
    }
}
