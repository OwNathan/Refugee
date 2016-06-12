using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour {

    public Button Slot;
    public Image ItemImage;
    public Text CountText;

    public InventoryItem Item { get; private set; }
    private int Count;
    private Image EmptyImage;

    void Awake()
    {
        Count = 0;
        Item = null;
        EmptyImage = ItemImage;
    }

    public void UpdateCounter(bool IsIncrementing)
    {
        if(IsIncrementing)
        {
            ItemImage.sprite = Item.Image.sprite;
            Count++;
            CountText.text = Count.ToString();
        }
        else
        {
            Count--;
            if (Count <= 0)
            {
                Count = 0;
                Item = null;
                CountText.text = string.Empty;
                
            }
            else
            {
                CountText.text = Count.ToString();
                ItemImage.sprite = EmptyImage.sprite;
            }
        }
    }

    public void SetItem(InventoryItem item)
    {
        Item = item;
        if(item.IsMultipleItem)
        {
            CountText.text = Count.ToString();
        }
        else
        {
            CountText.text = string.Empty;
        }
    }
}
