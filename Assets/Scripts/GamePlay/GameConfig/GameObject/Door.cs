using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : InteractableObject
{
    public DoorType thisDoorType;
    public bool isOpen = false;
    public PlayerInventory playerInventory;
    public InventoryItem requiredItem;
    public SpriteRenderer doorRenderer;
    public BoxCollider2D physicollider;
    public GameObject sceneTransition;
    public void Start()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& playerInRange)
        {
            if (playerInventory.currentInventory.Contains(requiredItem))
            {
                playerInventory.currentInventory.Remove(requiredItem);
                requiredItem.Use();
                Open();
            }
        }
    }

    public void Open()
    {
        doorRenderer.enabled =false;
        isOpen = true;
        physicollider.enabled =false;
        sceneTransition.SetActive(true);
    }
}
