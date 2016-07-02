using UnityEngine;
using System.Collections;

/// <summary>
/// enables and disables full screen skip button to prevent unwanted dialogues skip during cutscenes
/// usually mounted on DialogPanelUI
/// </summary>

public class FullScreenSkipDialogueController : MonoBehaviour
{
    public GameObject SkipButton;

    void OnEnable()
    {
        SkipButton.SetActive(true);
    }

 void OnDisable()
    {
        SkipButton.SetActive(false);
    }
}
