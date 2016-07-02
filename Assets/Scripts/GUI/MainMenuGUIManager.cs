using UnityEngine;
using System.Collections;
/// <summary>
/// Handles custom functions for main menu UI
/// </summary>
public class MainMenuGUIManager : MonoBehaviour
{

    public void OpenKickStarterPage()
    {
        Application.OpenURL("https://www.kickstarter.com/");
    }

    public void OpenGreenlightPage()
    {
        Application.OpenURL("https://steamcommunity.com/greenlight/");
    }
}
