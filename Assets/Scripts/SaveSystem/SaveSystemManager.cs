using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystemManager : MonoBehaviour
{
    private static string VariableResetScene = "_MAIN_MENU";
    private static Dictionary<string, int> resetDatabase = new Dictionary<string, int>();

    private static Dictionary<string, int> currentDatabase = new Dictionary<string, int>();
    private static int lastScene = -1;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == VariableResetScene)
        {
            if (resetDatabase.Count == 0)
            {
                InitializeResetDatabase();
            }
            else
            {
                VariableReset();
            }
        }
        else if (lastScene != SceneManager.GetActiveScene().buildIndex)
        {
            Save();
            lastScene = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            Load();
        }
    }

    private void InitializeResetDatabase()
    {
        DialogueManager.Instance.initialDatabase.variables.ForEach(hVar =>
        {
            string name = hVar.Name;
            int value = DialogueLua.GetVariable(hVar.Name).AsInt;
            resetDatabase.Add(name, value);
        });
    }


    private void VariableReset()
    {
        currentDatabase.Clear();
        resetDatabase.Keys.ToList().ForEach(hKey =>
        {
            string name = hKey;
            int value = resetDatabase[hKey];
            currentDatabase.Add(name, value);
        });

        //LOAD!!!
        Load();
    }

    //FROM DIALOGUESYSTEM TO SCRIPT
    private void Save()
    {
        currentDatabase.Clear();
        //Save Variables Initial Values
        DialogueManager.Instance.initialDatabase.variables.ForEach(hVar =>
        {
            string name = hVar.Name;
            int value = DialogueLua.GetVariable(hVar.Name).AsInt;
            currentDatabase.Add(name, value);
        });
    }

    //FROM SCRIPT TO DIALOGUESYSTEM
    private void Load()
    {
        //Load Variables Initial Values
        currentDatabase.Keys.ToList().ForEach(hKey =>
        {
            string name = hKey;
            int value = currentDatabase[hKey];
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable(name, value);
        });
    }
}