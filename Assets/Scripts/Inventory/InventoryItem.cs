using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//ITEM CONFIGURABILI TRAMITE LA FACTORY
[Serializable]
public class InventoryItem
{
    public string Name;
    public bool IsMultipleItem;
    public Sprite Image;

    public InventoryItem(string Name, bool IsMultipleItem, Sprite Image)
    {
        this.Name = Name;
        this.IsMultipleItem = IsMultipleItem;
        this.Image = Image;
    }

    public InventoryItem(InventoryItem item) : this(item.Name, item.IsMultipleItem, item.Image)
    {
        
    }
}