using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    /// <summary>
    /// enables and disables full screen skip button to prevent unwanted dialogues skip during cutscenes
    /// </summary>
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
