using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DebuggerDatabaseVarList : MonoBehaviour
{
    private List<string> variables;
    private string myLog = string.Empty;
    private bool isPanelActive;
    private Canvas canvas;
    private InputField input;
    private Text text;

    public void Awake()
    {
        variables = new List<string>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
        input = canvas.GetComponentInChildren<InputField>();
        text = canvas.GetComponentsInChildren<Text>().Last();
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
            {
                UpdatePanel();
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    private void UpdatePanel()
    {
        myLog = string.Empty;
        variables.ForEach(hVar => myLog += hVar + ": " + DialogueLua.GetVariable(hVar).AsInt + "\n");
    }

    public void OnVariableChanged()
    {
        string[] s = text.text.Trim().Split(new char[] { '=' });
        string variableName = s[0].Trim();
        int res;

        input.text = string.Empty;

        if(s.Length > 1)
        {
            if (int.TryParse(s[1], out res))
            {
                if (variables.Contains(variableName))
                {
                    PixelCrushers.DialogueSystem.DialogueLua.SetVariable(variableName, res);
                    UpdatePanel();
                    Debug.Log("VARIABLE CHANGED!");
                }
                else
                {
                    Debug.Log("Variable not found");
                }
            }
            else
            {
                Debug.Log("Can't parse value!");
            }
        }
        else
        {
            Debug.Log("Can't parse!");
        }
        
    }

    public void OnGUI()
    {
        if (isPanelActive)
            GUI.TextArea(new Rect(10f, 10f, Screen.width * 0.3f, Screen.height - 20f), myLog);
    }
}