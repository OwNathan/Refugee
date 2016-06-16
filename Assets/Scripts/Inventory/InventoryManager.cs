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
        Lua.RegisterFunction("AddItem", this, typeof(InventoryManager).GetMethod("AddItem"));
        Lua.RegisterFunction("RemoveItem", this, typeof(InventoryManager).GetMethod("RemoveItem"));
    }

    void OnDisable()
    {
        Lua.UnregisterFunction("FindItem");
        Lua.UnregisterFunction("AddItem");
        Lua.UnregisterFunction("RemoveItem");
    }

    public int FindItem(string name)
    {
        List<InventoryItem> myItems = Items.Select(kvp => kvp.Key).Where(hI => hI.Name == name).ToList();
        if (myItems == null)
        {
            return 0;
        }
        else
        {
            return myItems.Sum(hI => Items[hI]);
        }
    }
    public void AddItem(string name)
    {
        InventoryItem item = InventoryItemFactory.Instance.GetItem(name);
        if (item != null)
        {
            Add(item);
            Debug.Log("<color=green>Item Added: </color>" + name);
        }
        else
        {
            Debug.Log("<color=red>Can't Add Item: </color>" + name);
        }
    }
    public void RemoveItem(string name)
    {
        InventoryItem item = Items.Select(kvp => kvp.Key).Where(hI => hI.Name == name).FirstOrDefault();
        if (item != null)
        {
            Remove(item);
            Debug.Log("<color=green>Item Removed: </color>" + name);
        }
        else
        {
            Debug.Log("<color=red>Can't Remove Item: </color>" + name);
        }
    }
    #endregion

    //RIFERIMENTO AGLI ITEM CON IL LORO COUNTER
    private Dictionary<InventoryItem, int> Items;

    void Awake()
    {
        DontDestroyOnLoad(this);

        Items = new Dictionary<InventoryItem, int>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("<color=blue>INVENTORY:</color>");
            Items.ToList().ForEach(kvp => Debug.Log(kvp.Key.Name + ": " + kvp.Value));
        }
    }

    public void Add(InventoryItem item)
    {
        InventoryItem myItem = Items.Select(kvp => kvp.Key).Where(hI => hI.Name == item.Name).FirstOrDefault();
        if (myItem != null && item.IsMultipleItem)
        {
            Items[myItem]++;
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
            if (Items[item] == 0)
            {
                Items.Remove(item);
            }
        }
    }

}





