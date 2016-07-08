using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystemManager : MonoBehaviour
{
    private static Dictionary<string, int> initialDatabase = new Dictionary<string, int>();
    private static int lastScene = -1;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (lastScene != SceneManager.GetActiveScene().buildIndex)
        {
            Save();
            lastScene = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            Load();
        }
    }

    private void Save()
    {
        initialDatabase.Clear();
        //Save Variables Initial Values
        DialogueManager.Instance.initialDatabase.variables.ForEach(hVar =>
        {
            string name = hVar.Name;
            int value = DialogueLua.GetVariable(hVar.Name).AsInt;
            initialDatabase.Add(name, value);
        });
    }

    private void Load()
    {
        //Load Variables Initial Values
        initialDatabase.Keys.ToList().ForEach(hKey =>
        {
            string name = hKey;
            int value = initialDatabase[hKey];
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable(name, value);
        });
    }
}