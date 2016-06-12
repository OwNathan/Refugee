using UnityEngine;
using System.Collections;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class InventoryManager : MonoBehaviour
{
    #region LUA
    void OnEnable()
    {
        Lua.RegisterFunction("FindItem", this, typeof(InventoryManager).GetMethod("FindItem"));
    }

    void OnDisable()
    {
        Lua.UnregisterFunction("FindItem");
    }

    public int FindItem(string name)
    {
        return 0;
    }
    #endregion


}
