using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryGUIManager : MonoBehaviour
{
    public Animator InventoryAnimator;
    public List<InventorySlot> Slots;

    public void Add(InventoryItem item)
    {
        List<InventorySlot> fullSlots = this.Slots.Where(hS => hS.Item != null).ToList();
        List<InventorySlot> emptySlots = this.Slots.Where(hS => hS.Item == null).ToList();

        if (item != null)
        {
            InventorySlot slot;

            if (item.IsMultipleItem && fullSlots.Count != 0)
            {
                slot = fullSlots.Where(hS => hS.Item.Name == item.Name).FirstOrDefault();
                if (slot != null)
                {
                    slot.Add(item);
                }
                else
                {
                    emptySlots.FirstOrDefault().Add(item);
                }
            }
            else if (!item.IsMultipleItem && emptySlots.Count != 0)
            {
                emptySlots.FirstOrDefault().Add(item);
            }
            else
            {
                Debug.Log("<color=red>Can't Add Item On GUI!</color>");
            }
        }
        else
        {
            Debug.Log("<color=red>Can't Add Item On GUI!</color>");
        }

    }

    public void Remove(InventoryItem item)
    {
        List<InventorySlot> fullSlots = this.Slots.Where(hS => hS.Item != null).ToList();
        if (item != null && fullSlots != null)
        {
            InventorySlot slot = fullSlots.Where(hS => hS.Item.Name == item.Name).FirstOrDefault();
            if (slot != null)
            {
                slot.Remove(item);
            }
            else
            {
                Debug.Log("<color=red>Can't Find Item to Remove From GUI!</color>");
            }
        }
        else
        {
            Debug.Log("<color=red>Can't Remove Item From GUI!</color>");
        }
    }

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