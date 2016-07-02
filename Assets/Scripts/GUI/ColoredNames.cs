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
        guiManager = GameObject.FindObjectOfType<GUIManager>();
        characterTextName = this.gameObject.GetComponent<Text>();
    }
    // Use this for initialization
    void Start()
    {
        currentColor = guiManager.NameColor;

    }
    //Every scene has a different GUIManager so every time we load a level we need to refence it again
    //WARNING: this is for unity 5.3.4, it seems that in unity 5.4 (maybe also in the latest patch of 5.3?) this cakkback us deprecated. Use SceneManager instead.
    void OnLevelWasLoaded(int level)
    {
        guiManager = GameObject.FindObjectOfType<GUIManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentColor != guiManager.NameColor)
        {
            lastColor = currentColor;
            currentColor = guiManager.NameColor;
            characterTextName.color = currentColor;
        }
    }
}
