using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
/// <summary>
/// Called at start of every level to reset dialogues if active (like during quit to main menu)
/// Called in cutscenes to close dialogues when a scene need to be reloaded (eg. player death) in order to avoid dialogue desync
/// Needs to be placed in every scene
/// </summary>
public class ResetDialogueOnSceneReloading : MonoBehaviour
{
    void Start()
    {
        CloseDialogue();
    }

    public void CloseDialogue()
    {

        ConversationController conversation = DialogueManager.ConversationController;
        if (conversation != null)
            conversation.Close();
    }
}
