using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class DialogueSystem_SkipDialogue : MonoBehaviour
{

    public void CloseDialogue()
    {
        ConversationController conversation = DialogueManager.ConversationController;
        conversation.Close();
    }
}
