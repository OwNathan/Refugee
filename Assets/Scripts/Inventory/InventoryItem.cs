using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ITEM CONFIGURABILI TRAMITE LA FACTORY
public class InventoryItem
{
    public string Name;
    public bool IsMultipleItem;
    public Image Image;

    public InventoryItem(string Name, bool IsMultipleItem, Image Image)
    {
        this.Name = Name;
        this.IsMultipleItem = IsMultipleItem;
        this.Image = Image;
    }

    public InventoryItem(InventoryItem item) : this(item.Name, item.IsMultipleItem, item.Image)
    {
        
    }
}