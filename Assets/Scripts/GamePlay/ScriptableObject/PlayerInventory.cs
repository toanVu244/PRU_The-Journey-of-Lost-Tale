using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerInventory", menuName = "Inventory/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> currentInventory = new List<InventoryItem>();
}
