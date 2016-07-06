using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Used for change color in DialogueUI->NPC Text Name
/// </summary>

[RequireComponent(typeof(Text))]
public class ColoredNames : MonoBehaviour
{
    private Text characterTextName;
    private GUIManager guiManager;
    private Color currentColor;
    private Color lastColor;
    void Awake()
    {
        characterTextName = this.gameObject.GetComponent<Text>();
    }
    // Use this for initialization
    void Start()
    {
        guiManager = GameObject.FindObjectOfType<GUIManager>();

        if (guiManager != null)
            currentColor = GUIManager.NameColor;
    }
    ////Every scene has a different GUIManager so every time we load a level we need to refence it again
    ////WARNING: this is for unity 5.3.4, it seems that in unity 5.4 (maybe also in the latest patch of 5.3?) this cakkback us deprecated. Use SceneManager instead.
    //void OnLevelWasLoaded(int level)
    //{
    //    guiManager = GameObject.FindObjectOfType<GUIManager>();
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        if(guiManager != null)
            guiManager = GameObject.FindObjectOfType<GUIManager>();

        if (currentColor != GUIManager.NameColor)
        {
            lastColor = currentColor;
            currentColor = GUIManager.NameColor;
            characterTextName.color = currentColor;
        }
    }
}
