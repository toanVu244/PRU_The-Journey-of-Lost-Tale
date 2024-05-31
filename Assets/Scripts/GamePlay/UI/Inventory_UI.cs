using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Refresh();
            ToggleInvertoryUI();
        }
    }

    public void ToggleInvertoryUI()
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
        }
        else
            inventoryPanel.SetActive(false);
    }

    public void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count) 
        {
            for(int i = 0; i < slots.Count; i++) 
            {
                if (player.inventory.slots[i].type != Collectable.CollectableType.None)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Drop(int slotIndex)
    {
        Collectable itemToDrop = GameManager.Instance.ItemManager.GetItemByType(player.inventory.slots[slotIndex].type);
        if(itemToDrop != null)
        {
            player.DropLocate(itemToDrop);
            player.inventory.Drop(slotIndex);
            Refresh();
        }
    }
}
