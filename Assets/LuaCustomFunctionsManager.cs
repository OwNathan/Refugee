using UnityEngine;
using System.Collections;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class LuaCustomFunctionsManager : MonoBehaviour
{
    void OnEnable()
    {
        Lua.RegisterFunction("FindItem", this, typeof(LuaCustomFunctionsManager).GetMethod("FindItem"));
    }

    void OnDisable()
    {
        Lua.UnregisterFunction("FindItem");
    }

    public int FindItem(string name)
    {
        return 0;
    }
}
