using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    }
}

