/// MainMenu.cs
/// Holds the functions required for Main Menu Navigation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Opens the Main Game Scene for Freeplay
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    /// <summary>
    /// Opens the Main Menu Scene
    /// </summary>
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
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
