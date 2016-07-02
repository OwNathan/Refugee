using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
/// <summary>
/// Called in cutscenes to close dialogues when a scene need to be reloaded (eg. player death) in order to avoid dialogue desync
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
