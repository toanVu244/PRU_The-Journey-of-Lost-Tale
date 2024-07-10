using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem: ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int numberHeld;
    public UnityEvent thisEvent;

    public void Use()
    {
        numberHeld--;
        thisEvent.Invoke();
    }
}
