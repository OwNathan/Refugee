using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//INVENTARIO DI GIOCO
public class InventoryManager : MonoBehaviour
{
    #region LUA

    private void OnEnable()
    {
        Lua.RegisterFunction("FindItem", this, typeof(InventoryManager).GetMethod("FindItem"));
        Lua.RegisterFunction("AddItem", this, typeof(InventoryManager).GetMethod("AddItem"));
        Lua.RegisterFunction("RemoveItem", this, typeof(InventoryManager).GetMethod("RemoveItem"));
    }

    private void OnDisable()
    {
        Lua.UnregisterFunction("FindItem");
        Lua.UnregisterFunction("AddItem");
        Lua.UnregisterFunction("RemoveItem");
    }

    public int FindItem(string name)
    {
        List<InventoryItem> myItems = items.Select(kvp => kvp.Key).Where(hI => hI.Name == name).ToList();
        if (myItems == null)
        {
            return 0;
        }
        else
        {
            return myItems.Sum(hI => items[hI]);
        }
    }

    public void AddItems(string name, int count)
    {
        for (int i = 0; i < count; i++)
        {
            AddItem(name);
        }
    }
    public void RemoveItems(string name, int count)
    {
        for (int i = 0; i < count; i++)
        {
            RemoveItem(name);
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
        InventoryItem item = items.Select(kvp => kvp.Key).Where(hI => hI.Name == name).FirstOrDefault();
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

    #endregion LUA

    //RIFERIMENTO AGLI ITEM CON IL LORO COUNTER
    private Dictionary<InventoryItem, int> items;
    private InventoryGUIManager inventoryGUI;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        items = new Dictionary<InventoryItem, int>();
    }

    private void Start()
    {
        inventoryGUI = AC.PlayerMenus.GetMenuWithName("RefugeeInventory").canvas.gameObject.GetComponent<InventoryGUIManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("<color=blue>INVENTORY:</color>");
            items.ToList().ForEach(kvp => Debug.Log(kvp.Key.Name + ": " + kvp.Value));
        }
    }

    public void Add(InventoryItem item)
    {
        if (item != null)
        {
            InventoryItem myItem = items.Select(kvp => kvp.Key).Where(hI => hI.Name == item.Name).FirstOrDefault();
            if (myItem != null && item.IsMultipleItem)
            {
                items[myItem]++;
                //UPDATE ON GUI
                inventoryGUI.Add(myItem);
            }
            else
            {
                items.Add(item, 1);
                //UPDATE ON GUI
                inventoryGUI.Add(item);
            }
        }
        else
        {
            Debug.Log("<color=red>CAN'T ADD ITEM!</color>");
        }
    }

    public void Remove(InventoryItem item)
    {
        if (item != null && items.ContainsKey(item))
        {
            items[item]--;
            if (items[item] == 0)
            {
                items.Remove(item);
            }
            //UPDATE ON GUI
            inventoryGUI.Remove(item);
        }
        else
        {
            Debug.Log("<color=red>CAN'T REMOVE ITEM!</color>");
        }
    }
}