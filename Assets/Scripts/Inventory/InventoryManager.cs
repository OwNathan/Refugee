using UnityEngine;
using System.Collections;
using PixelCrushers;
using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using System.Linq;

//INVENTARIO DI GIOCO
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
        List<InventoryItem> myItems = Items.Select(kvp => kvp.Key).Where(hI => hI.Name == name).ToList();
        if(myItems == null)
        {
            return 0;
        }
        else
        {
            return myItems.Sum(hI => Items[hI]);
        }
    }
    #endregion

    //RIFERIMENTO AGLI ITEM CON IL LORO COUNTER
    private Dictionary<InventoryItem, int> Items;

    void Awake()
    {
        Items = new Dictionary<InventoryItem, int>();
    }

    public void Add(InventoryItem item)
    {
        if (Items.ContainsKey(item) && item.IsMultipleItem)
        {
            Items[item]++;
        }
        else
        {
            Items.Add(item, 1);
        }
    }
    public void Remove(InventoryItem item)
    {
        if (Items.ContainsKey(item))
        {
            Items[item]--;
            if(Items[item] == 0)
            {
                Items.Remove(item);
            }
        }
    }
}





