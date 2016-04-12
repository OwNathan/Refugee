using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDebugLogger : MonoBehaviour
{
    private List<Variable> variables;
    private string myLog = string.Empty;
    private bool isPanelActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPanelActive = !isPanelActive;
            if (isPanelActive)
            {
                myLog = string.Empty;
                UpdatePanel();
            }
        }
    }

    private void UpdatePanel()
    {
        variables = DialogueManager.Instance.DatabaseManager.MasterDatabase.variables;
        variables.ForEach(hV =>
        {
            myLog += "[" + hV.Type + "]";
            hV.fields.ForEach(hF =>
            {
                myLog += hF.value + " ";
            });
            myLog += "\n";
        });
    }

    public void OnGUI()
    {
        if (isPanelActive)
        {
            GUI.TextArea(new Rect(10, 10, Screen.width - 10, Screen.height - 10), myLog);
        }
    }
}