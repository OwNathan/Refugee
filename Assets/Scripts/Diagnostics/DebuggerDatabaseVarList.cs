using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerDatabaseVarList : MonoBehaviour
{
    private List<string> variables;
    private string myLog = string.Empty;
    private bool isPanelActive;

    public void Awake()
    {
        variables = new List<string>();
    }

    public void Start()
    {
        DialogueManager.Instance.initialDatabase.variables.ForEach(hVar => variables.Add(hVar.Name));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPanelActive = !isPanelActive;

            if (isPanelActive)
                UpdatePanel();
        }
    }

    private void UpdatePanel()
    {
        myLog = string.Empty;
        variables.ForEach(hVar => myLog += hVar + ": " + DialogueLua.GetVariable(hVar).AsInt + "\n");
    }

    public void OnGUI()
    {
        if (isPanelActive)
            GUI.TextArea(new Rect(10, 10, Screen.width - 10, Screen.height - 10), myLog);
    }
}