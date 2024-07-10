using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantity;

    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void SetUp(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemIcon.sprite = thisItem.itemImage;
            quantity.text = "" + thisItem.numberHeld;
        }
    }
}
