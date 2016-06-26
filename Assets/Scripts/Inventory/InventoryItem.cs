using System;
using UnityEngine;

//ITEM CONFIGURABILI TRAMITE LA FACTORY
[Serializable]
public class InventoryItem
{
    public string Name;
    public bool IsMultipleItem;
    public int MaxCount;
    public Sprite Icon;

    public InventoryItem(string Name, bool IsMultipleItem, int MaxCount, Sprite Image)
    {
        this.Name = Name;
        this.IsMultipleItem = IsMultipleItem;
        this.Icon = Image;
        this.MaxCount = MaxCount;
    }

    public InventoryItem(InventoryItem item) : this(item.Name, item.IsMultipleItem, item.MaxCount, item.Icon)
    {
    }
}