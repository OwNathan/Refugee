using UnityEngine;
using System.Collections;

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
