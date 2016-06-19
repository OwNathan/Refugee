using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem Item { get; private set; }

    private Image               icon;           //icona
    private Button              button;         //non so
    private Text                text;           //testo per il contatore

    private Sprite              emptySprite;    //sprite di base
    private int                 counter;

    private void Awake()
    {
        icon = this.GetComponent<Image>();
        emptySprite  = icon.sprite;
        button = this.GetComponent<Button>();
        text = this.GetComponentInChildren<Text>();
    }
    
    public void Add(InventoryItem item)
    {
        if(Item == null)
            Item = item;
        text.text = (++counter).ToString();
        icon.sprite = item.Icon;
    }
    public void Remove(InventoryItem item)
    {
        text.text = (--counter).ToString();
        if (counter == 0)
        {
            Item = null;
            text.text = string.Empty;
            icon.sprite = emptySprite;
        }
        else
        {
            text.text = counter.ToString();
        }
    }
    #region OLD
    //public void UpdateCounter(bool IsIncrementing)
    //{
    //    if (IsIncrementing)
    //    {
    //        ItemImage.sprite = Item.Image;
    //        Count++;
    //        CountText.text = Count.ToString();
    //    }
    //    else
    //    {
    //        Count--;
    //        if (Count <= 0)
    //        {
    //            Count = 0;
    //            Item = null;
    //            CountText.text = string.Empty;
    //        }
    //        else
    //        {
    //            CountText.text = Count.ToString();
    //            ItemImage.sprite = EmptyImage;
    //        }
    //    }
    //}

    //public void SetItem(InventoryItem item)
    //{
    //    if (item != null)
    //    {
    //        Item = item;
    //        ItemImage.sprite = item.Image;
    //        if (item.IsMultipleItem)
    //        {
    //            CountText.text = Count.ToString();
    //        }
    //        else
    //        {
    //            CountText.text = string.Empty;
    //        }
    //    }
    //    else
    //    {
    //        Item = null;
    //        ItemImage.sprite = EmptyImage;
    //    }
    //}
    #endregion
}