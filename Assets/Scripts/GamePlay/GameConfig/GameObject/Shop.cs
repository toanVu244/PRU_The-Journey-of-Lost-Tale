using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : InteractableObject
{
    public PlayerInventory playerInventory;
    public InventoryItem requiredItem;
    public InventoryItem itemSell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInventory.currentInventory.Contains(requiredItem))
            {
                requiredItem.Use();
                if (playerInventory.currentInventory.Contains(itemSell))
                {
                    itemSell.numberHeld++;
                }
                else
                {
                    playerInventory.currentInventory.Add(itemSell);
                    itemSell.numberHeld++;
                }
            }
        }
    }
}
