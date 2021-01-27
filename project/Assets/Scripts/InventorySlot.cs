using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // 인벤토리 슬롯의 아이템 아이콘, 설명, 개수를 바꾸는 역할
    public Image icon;
    public Text itemName_Text;
    public Text itemCount_Text;
    public GameObject selected_Item;

    public void AddItem(Item _item)
    {
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        if(Item.ItemType.Use == _item.itemType)
        {
            if(_item.itemCount > 0)
            {
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            } else
            {
                itemCount_Text.text = "";
            }
        }
    }

    public void RemoveItem()
    {
        itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
}
