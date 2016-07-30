using UnityEngine;
using System.Collections;
/// <summary>
/// Handles custom functions for main menu UI
/// </summary>
public class MainMenuGUIManager : MonoBehaviour
{

    public void OpenKickStarterPage()
    {
        Application.OpenURL("https://www.kickstarter.com/projects/1346867743/1687337565?token=5b6e35ad");
    }

    public void OpenGreenlightPage()
    {
        Application.OpenURL("https://steamcommunity.com/greenlight/");
    }
}
