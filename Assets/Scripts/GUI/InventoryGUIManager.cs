using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class InventoryGUIManager : MonoBehaviour
{

    public Animator InventoryAnimator;
    public List<InventorySlot> Slots;

    #region ManageGraphicInventory

    public void AddItem(InventoryItem item)
    {
        if (item.IsMultipleItem)
        {
            InventorySlot tmpSlot = Slots.Where(hI => hI.Item == item).FirstOrDefault();
            if (tmpSlot != null)
            {
                tmpSlot.UpdateCounter(true);
            }
            else
            {
                Slots.ForEach(hS => {
                    hS.SetItem(item);
                    hS.UpdateCounter(true);
                });
            }
        }
        else
        {
            Slots.Where(hS => hS.Item == null).FirstOrDefault().SetItem(item);
        }
    }

    public void RemoveItem(InventoryItem item)
    {
        if (item.IsMultipleItem)
        {
            InventorySlot tmpSlot = Slots.Where(hI => hI.Item == item).FirstOrDefault();
            if(tmpSlot != null)
            {
                tmpSlot.UpdateCounter(false);
            }
            else
            {
                Slots.Where(hI => hI.Item == item).FirstOrDefault().SetItem(null);
            }
        }
    }
    
    #endregion

    #region CycleInventory
    public void OnClickRight()
    {
        InventoryAnimator.SetBool("GoRight", true);
    }
    public void OnClickLeft()
    {
        InventoryAnimator.SetBool("GoLeft", true);
    }
    #endregion
}
