using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
/// <summary>
/// Called by UI full screen panel in order to skip dialogues just by clicking everywhere on the screen
/// </summary>
public class DialogueSystem_SkipDialogue : MonoBehaviour
{

    public void CloseDialogue()
    {
        
        ConversationController conversation = DialogueManager.ConversationController;
        if (conversation != null)
            conversation.Close();
    }
}
