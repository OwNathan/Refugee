using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

//FABBRICA DI ITEM CONFIGURABILI DA INSPECTOR
public class InventoryItemFactory : MonoBehaviour
{
    public static InventoryItemFactory Instance;
    public List<InventoryItem> Items;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    internal InventoryItem GetItem(string name)
    {
        InventoryItem item = Items.Where(hI => hI.Name == name).FirstOrDefault();
        if(item != null)
        {
            return new InventoryItem(item);
        }
        return null; 
    }
}

